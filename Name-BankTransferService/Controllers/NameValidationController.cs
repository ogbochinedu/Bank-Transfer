using BankService.Application.Command.Transfers.Validators;
using BankService.Application.Queries.NameValidation;
using BankService.Application.Queries.NameValidation.Validators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Name_BankTransferService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NameValidationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NameValidationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("validate")]
        public async Task<IActionResult> ValidateName([FromQuery] ValidateNameQuery query)
        {
            try
            {
                var validator = new ValidateNameValidator();
                var validationResult = validator.Validate(query);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors.Select(e => new
                    {
                        Property = e.PropertyName,
                        Error = e.ErrorMessage
                    }));
                }
                var result = await _mediator.Send(query);
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
