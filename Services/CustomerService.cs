﻿using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Exceptions;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        CustomerDto GetCustomerById(int customerId);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).Include(c => c.RoleType);

            return customers;
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).Include(c => c.RoleType).SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new NotFoundException("Customer not found");
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;

        }

    }
}
