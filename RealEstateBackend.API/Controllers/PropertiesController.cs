using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstateBackend.Application.Features.Property.Commands.CreateProperty;
using RealEstateBackend.Application.Features.Property.Commands.DeleteProperty;
using RealEstateBackend.Application.Features.Property.Commands.UpdateProperty;
using RealEstateBackend.Application.Features.Property.Queries.GetProperties;
using RealEstateBackend.Application.Features.Property.Queries.GetProperty;

namespace RealEstateBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        /*        private readonly ILogger _logger;*/

        public PropertiesController(IMediator mediator)
        {
            _mediator = mediator;
            /*            _logger = logger;*/
        }

        [HttpGet("GetProperties")]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await _mediator.Send(new GetPropertiesQuery());
            return Ok(properties);
        }

        [HttpGet("GetProperty")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await _mediator.Send(new GetPropertyQuery(id));
            return Ok(property);
        }

        [HttpPost("CreateProperty")]
        public async Task<IActionResult> CreateProperty(PropertyDto propertyDto)
        {
            var data = await _mediator.Send(new CreatePropertyCommand(propertyDto));

            return Ok(data);

        }

        [HttpPut("UpdateProperty/{id}")]
        public async Task<IActionResult> UpdateProperty(int id, PropertyDto propertyDto)
        {
            var updateCommand = new UpdatePropertyCommand(id, propertyDto);

            var result = await _mediator.Send(updateCommand);

            if (result != null)
            {
                return Ok("Property updated successfully");
            }
            else
            {
                return BadRequest("Failed to update property");
            }
        }

        [HttpDelete("DeleteProperty")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var propertyy = await _mediator.Send(new DeletePropertyCommand(id));
            return Ok(propertyy);
        }

    }
}
