using RealEstate.Core.DTO;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Repositories
{
    public interface IFavoriteRepository
    {
        Task<bool> AddFavoriteAsync(string userId, Guid propertyId);
        Task<bool> RemoveFavoriteAsync(string userId, Guid propertyId);
        Task<(IEnumerable<PropertyDto>,int)> GetFavoritesByUserAsync(string userId, int pageNumber, int pageSize);
        Task<(bool, Favorite?)> IsFavoriteAsync(string userId, Guid propertyId);
    }
}
