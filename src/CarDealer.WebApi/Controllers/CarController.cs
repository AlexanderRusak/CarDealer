using CarDealer.BusinessLogic;
using CarDealer.BusinessLogic.Commands;
using CarDealer.BusinessLogic.Dtos;
using CarDealer.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.WebApi.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all")]

        public async Task<IActionResult> Get()
        {
            var query = new GetAllCarsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCarCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Error)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
