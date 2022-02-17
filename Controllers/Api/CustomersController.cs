﻿using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using LibApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET /api/customers
        [HttpGet]
        [Authorize(Roles = "User, StoreManager, Owner")]
        public IActionResult GetAllCustomers()
        {
            var result = customerService.GetAllCustomers();

            return Ok(result);
        }

        // GET /api/customers/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult GetCustomerById(int id)
        {
            var result = customerService.GetCustomerById(id);

            return Ok(result);
        }

        // POST /api/customers
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public IActionResult CreateNewCustomer(CustomerUpdateCreateDto createCustomerDto)
        {
            var result = customerService.CreateNewCustomer(createCustomerDto);

            return Created($"api/customers/{result}", null);
        }

        // PUT /api/customers 
        [HttpPut("{id}")]
        [Authorize(Roles = "Owner")]
        public IActionResult UpdateCustomer(int id, CustomerUpdateCreateDto updateCustomerDto)
        {
            customerService.UpdateCustomer(id, updateCustomerDto);

            return Ok();
        }

        // DELETE /api/customers
        [HttpDelete("{id}")]
        [Authorize(Roles = "Owner")]
        public IActionResult DeleteCustomer(int id)
        {
            customerService.DeleteCustomer(id);

            return Ok();
        }

    }
}