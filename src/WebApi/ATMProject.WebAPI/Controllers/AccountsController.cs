using ATMProject.Application.CQRS.Commands.Accounts;
using ATMProject.Application.CQRS.Queries.Acounts;
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

        [HttpPost] 
        public async Task<IActionResult> Add(CreateAccountCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AddCash(AddCashCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllAccountQuery());
            return Ok(result);
        }

    }
}
