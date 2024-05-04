﻿using ClassLibraryGameShop;
using Microsoft.AspNetCore.Mvc;
using TestShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet("GetCustomers")]
        public IEnumerable<Customer> Get()
        {
            var customers = new CustomerDB().Read();
            return customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("GetCustomerById")]
        public Customer Get(string id)
        {
            return new CustomerDB().GetById(id);
        }
        // GET api/<CustomerController>/5
        [HttpGet("GetCustomerByEmail")]
        public Customer GetByEmail(string email)
        {
            return new CustomerDB().GetByEmail(email);
        }

        // POST api/<CustomerController>
        [HttpPost(Name = "NewCustomer")]
        public void Post(string id, string firstName, string lastName, string patronymicName, string email, DateTime birthday, string address, string passwordHash)
        {
            new CustomerDB().Create(id, firstName,  lastName,  patronymicName, email, birthday, address, passwordHash);
        }

        // PUT api/<CustomerController>/5
        [HttpPut(Name = "UpdateCustomer")]
        public void Put(string id, string firstName, string lastName, string patronymicName, string email, DateTime birthday, string address, string passwordHash)
        {
            new CustomerDB().Update(id, firstName, lastName,  patronymicName, email, birthday, address, passwordHash);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete(Name = "Customer/{id}")]
        public void Delete(string id)
        {
            new CustomerDB().Delete(id);
        }
    }
}
