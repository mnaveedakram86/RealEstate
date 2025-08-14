using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.DTO;
using RealEstate.Services;
using System.Security.Claims;

namespace RealEstate.Api.Controllers
{
    [ApiController]
    [Route("api/favorites")]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favService;
        public FavoritesController(IFavoriteService favService) { _favService = favService; }

        [HttpPost("{propertyId}")]
        public async Task<IActionResult> Add(Guid propertyId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (await _favService.AddFavoriteAsync(userId, propertyId))
                return CreatedAtAction(null, null);
            else
                return NotFound();
        }

        [HttpDelete("{propertyId}")]
        public async Task<IActionResult> Remove(Guid propertyId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (await _favService.RemoveFavoriteAsync(userId, propertyId)) { return NoContent(); }
            return NotFound();
        }

        [HttpGet]
        public async Task<PagedResultDto<PropertyDto>> Get(int pageNumber = 1, int pageSize = 10)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var (properties, totalRecords) = await _favService.GetFavoritesByUserAsync(userId, pageNumber, pageSize);
            return new PagedResultDto<PropertyDto>
            {
                Listing = properties,
                TotalRecords = totalRecords
            };
        }
    }
}
