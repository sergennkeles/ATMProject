﻿using ATMProject.Application.CQRS.Commands;
using ATMProject.Application.CQRS.Commands.Customers;
using ATMProject.Application.CQRS.Queries.Customers;
using ATMProject.Application.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var list = await mediator.Send(new GetAllCustomerQuery());
            return Ok(list);
        }

        [HttpGet("getallwithaccount")]
        public async Task<IActionResult> GetAllCustomerWithAccount()
        {
            var list = await mediator.Send(new GetAllCustomerWithAccountQuery());
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCustomerCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdCustomer = await mediator.Send(new GetByIdCustomerQuery() { Id=id});
            return Ok(getByIdCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommand command)
        {
            var updatedCustomer=await mediator.Send(command);
            return Ok(updatedCustomer);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var deletedCustomer=await mediator.Send(new DeleteCustomerCommand() { Id=id});
            return Ok(deletedCustomer);
        }
    }
}