using RealEstate.Core.DTO;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Services
{
    public class FavoriteService : IFavoriteService
    {
        public readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository ) {
            this._favoriteRepository = favoriteRepository; 
        }
        public async Task<bool> AddFavoriteAsync(string userId, Guid propertyId)
        {
           return await this._favoriteRepository.AddFavoriteAsync(userId, propertyId);
        }
        public async Task<bool> RemoveFavoriteAsync(string userId, Guid propertyId)
        {
           return await this._favoriteRepository.RemoveFavoriteAsync(userId, propertyId);
        }
        public async Task<(IEnumerable<PropertyDto>, int)> GetFavoritesByUserAsync(string userId, int pageNumber, int pageSize)
        {
            return await this._favoriteRepository.GetFavoritesByUserAsync(userId, pageNumber, pageSize);
        }

        

    }
}