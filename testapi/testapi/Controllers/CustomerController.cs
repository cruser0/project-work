﻿using API.Models.DTO;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Mapper;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }



        // GET: api/<CustomerController>

        [Authorize(Roles = "Admin,CustomerRead,CustomerWrite,CustomerAdmin,SaleWrite,SaleAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerFilter filter)
        {
            var data = await _customerService.GetAllCustomers(filter);
            if (data.Any())
            {
                return Ok(data);
            }
            else throw new NotFoundException("Customer not found");
        }



        [Authorize(Roles = "Admin,CustomerRead,CustomerWrite,CustomerAdmin,SaleWrite,SaleAdmin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount([FromQuery] CustomerFilter filter)
        {
            var data = await _customerService.CountCustomers(filter);
            return Ok(data);
        }



        // GET api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerRead,CustomerWrite,CustomerAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
                var data = await _customerService.GetCustomerById(id);
                if (data == null)
                    throw new NotFoundException("Customer not found!");
                return Ok(data);
        }




        // POST api/<CustomerController>
        [Authorize(Roles = "Admin,CustomerWrite,CustomerAdmin")]
        [HttpPost]
        public async Task<IActionResult> Post(CustomerDTO customer)
        {
                var data = await _customerService.CreateCustomer(CustomerMapper.Map(customer));
                if (data == null)
                    throw new NotFoundException("Data can't be null!");
                return Ok(data);
        }




        // PUT api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerWrite,CustomerAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDTO customer)
        {
            var data = await _customerService.UpdateCustomer(id, CustomerMapper.Map(customer));
            if (data == null)
                throw new NotFoundException("Customer not found!");
            return Ok(data);
        }




        // DELETE api/<CustomerController>/5
        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _customerService.DeleteCustomer(id);
            if (data == null)
                throw new NotFoundException("Customer not found!");
            return Ok(data);
        }




        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpDelete("mass-delete")]
        public async Task<IActionResult> MassDelete([FromQuery] List<int> id)
        {
            var data = await _customerService.MassDeleteCustomer(id);
            return Ok(data);
        }




        [Authorize(Roles = "Admin,CustomerAdmin")]
        [HttpPut("mass-update")]
        public async Task<IActionResult> MassUpdate([FromBody] List<CustomerDTOGet> newCustomers)
        {
                var data = await _customerService.MassUpdateCustomer(newCustomers);
                return Ok(data);
        }
    }
}
