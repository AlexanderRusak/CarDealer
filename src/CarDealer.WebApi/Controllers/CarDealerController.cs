using CarDealer.BusinessLogic;
using CarDealer.BusinessLogic.Commands;
using CarDealer.BusinessLogic.Dtos;
using CarDealer.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.WebApi.Controllers
{
    [ApiController]
    [Route("api/car-dealer")]
    public class CarDealerController : ControllerBase
    {


        private readonly IMediator _mediator;


        public CarDealerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllDealerCarsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddDealerCarCommand command)
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