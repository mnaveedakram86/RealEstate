using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.DTO;
using RealEstate.Core.Entities;
using RealEstate.Services;
using System.Security.Claims;
namespace RealEstate.Api.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service;
        private readonly IMapper _mapper;
        public PropertiesController(IPropertyService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<PagedResultDto<PropertyDto>> Get([FromQuery] PropertyFilter filter)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var (properties, totalRecords) = await _service.GetFilteredAsync(userId, filter);
            return new PagedResultDto<PropertyDto>
            {
                Listing = properties,
                TotalRecords = totalRecords
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prop = await _service.GetByIdAsync(id);
            if (prop == null) return NotFound();
            return Ok(_mapper.Map<PropertyDto>(prop));
        }
    }
}
