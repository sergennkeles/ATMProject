using ATMProject.Application.CQRS.Commands;
using ATMProject.Application.CQRS.Commands.Accounts;
using ATMProject.Application.CQRS.Commands.Customers;
using ATMProject.Application.CQRS.Queries.Acounts;
using ATMProject.Application.CQRS.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPatch("addcash")]
        public async Task<IActionResult> AddCash(AddCashCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpPatch("withdrawcash")]
        public async Task<IActionResult> WithDrawCash(WithDrawCashCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch("add")]
        public async Task<IActionResult> Add(CreateCustomerCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getallaccount")]
        public async Task<IActionResult> GetAllAccount()
        {
            var result = await mediator.Send(new GetAllAccountQuery());
            return Ok(result);
        }



        [HttpGet("getalluser")]
        public async Task<IActionResult> GetAllUser()
        {
            var list = await mediator.Send(new GetAllUserQuery());
            return Ok(list);
        }

        [HttpGet("getallwithaccount")]
        public async Task<IActionResult> GetAllCustomerWithAccount()
        {
            var list = await mediator.Send(new GetAllCustomerWithAccountQuery());
            return Ok(list);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdCustomer = await mediator.Send(new GetByIdUserQuery() { Id = id });
            return Ok(getByIdCustomer);
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var updatedCustomer = await mediator.Send(command);
            return Ok(updatedCustomer);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var deletedCustomer = await mediator.Send(new DeleteCustomerCommand() { Id = id });
            return Ok(deletedCustomer);
        }

    }
}
