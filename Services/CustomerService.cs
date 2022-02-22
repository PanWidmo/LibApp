using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Exceptions;
using LibApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibApp.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        CustomerDto GetCustomerById(int customerId);
        int CreateNewCustomer(CustomerUpdateCreateDto createCustomerDto);
        void UpdateCustomer(int customerId, CustomerUpdateCreateDto updateCustomerDto);
        void DeleteCustomer(int customerId);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<Customer> passwordHasher;

        public CustomerService(ApplicationDbContext context, IMapper mapper, IPasswordHasher<Customer> passwordHasher)
        {
            this.context = context;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = context.Customers.Include(c => c.MembershipType).Include(c => c.RoleType);

            return customers;
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            var customer = context.Customers.Include(c => c.MembershipType).Include(c => c.RoleType).SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new NotFoundException("Customer not found");
            }

            var customerDto = mapper.Map<CustomerDto>(customer);

            return customerDto;

        }

        public int CreateNewCustomer (CustomerUpdateCreateDto createCustomerDto)
        {
            var newCustomer = new Customer
            {
                Name = createCustomerDto.Name,
                Email = createCustomerDto.Email,
                PasswordHash = createCustomerDto.PasswordHash,
                MembershipTypeId = createCustomerDto.MembershipTypeId,
                HasNewsletterSubscribed = createCustomerDto.HasNewsletterSubscribed,
                Birthdate = createCustomerDto.Birthdate,
                RoleTypeId = createCustomerDto.RoleTypeId
            };

            var hashedPassword = passwordHasher.HashPassword(newCustomer, createCustomerDto.PasswordHash);
            newCustomer.PasswordHash = hashedPassword;

            context.Customers.Add(newCustomer);
            context.SaveChanges();

            return newCustomer.Id;
        }

        public void UpdateCustomer(int customerId, CustomerUpdateCreateDto updateCustomerDto)
        {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == customerId);

            if(customerInDb == null)
            {
                throw new NotFoundException("Customer not found");
            }

            mapper.Map(updateCustomerDto, customerInDb);
            context.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == customerId);

            if (customerInDb == null)
            {
                throw new NotFoundException("Customer not found");
            }

            context.Customers.Remove(customerInDb);
            context.SaveChanges();

        }

    }
}
