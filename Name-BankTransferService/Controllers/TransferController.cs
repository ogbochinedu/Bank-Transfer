using BankService.Application.Command.Transfers;
using BankService.Application.Command.Transfers.Validators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Name_BankTransferService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer([FromBody] CreateTransferCommand command)
        {
            try
            {
                var validator = new CreateTransferValidator();
                var validationResult = validator.Validate(command);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => new
                    {
                        Property = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
