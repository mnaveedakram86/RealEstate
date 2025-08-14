using RealEstate.Core.DTO;

namespace RealEstate.Services
{
    public interface IFavoriteService
    {
        Task<bool> AddFavoriteAsync(string userId, Guid propertyId);
        Task<bool> RemoveFavoriteAsync(string userId, Guid propertyId);
        Task<(IEnumerable<PropertyDto>, int)> GetFavoritesByUserAsync(string userId, int pageNumber, int pageSize);
    }
}
