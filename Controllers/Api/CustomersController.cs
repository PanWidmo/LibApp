using AutoMapper;
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
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET /api/customers
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetAllCustomers();

            return Ok(result);
        }

        // GET /api/customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var result = _customerService.GetCustomerById(id);

            return Ok(result);
        }

        // POST /api/customers
        [HttpPost]
        public ActionResult CreateNewCustomer(CustomerUpdateCreateDto createCustomerDto)
        {
            var result = _customerService.CreateNewCustomer(createCustomerDto);

            return Created($"api/customers/{result}", null);
        }

        // PUT /api/customers 
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, CustomerUpdateCreateDto updateCustomerDto)
        {
            _customerService.UpdateCustomer(id, updateCustomerDto);

            return Ok();
        }

        // DELETE /api/customers
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);

            return Ok();
        }

        private readonly ICustomerService _customerService;
    }
}