using Microsoft.EntityFrameworkCore;
using RealEstate.Core.DTO;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _appDbContext;

        public FavoriteRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<bool> AddFavoriteAsync(string userId, Guid propertyId)
        {
            var (isFavorite, favorite) = await IsFavoriteAsync(userId, propertyId);
            if (isFavorite) return true;

            _appDbContext.Favorites.Add(new Favorite { PropertyId = propertyId, UserId = userId });
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFavoriteAsync(string userId, Guid propertyId)
        {
            var (isFavorite, favorite) = await IsFavoriteAsync(userId, propertyId);
            if (isFavorite)
            {
                _appDbContext.Favorites.Remove(favorite);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<(IEnumerable<PropertyDto>, int)> GetFavoritesByUserAsync(string userId, int pageNumber, int pageSize)
        {
            var q = this._appDbContext.Favorites.AsQueryable();
            q = q
                .Where(f => f.UserId == userId)
                .Include(f => f.Property);
            var totalRecords = (int)Math.Ceiling((double)await q.CountAsync() / pageSize);
            var properties = await q.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(f => new PropertyDto
                {
                    Id = f.Property.Id,
                    Title = f.Property.Title,
                    Price = f.Property.Price,
                    Address = f.Property.Address,
                    PropertyType = f.Property.PropertyType,
                    Bedrooms = f.Property.Bedrooms,
                    Bathrooms = f.Property.Bathrooms,
                    CarSpots = f.Property.CarSpots,
                    Description = f.Property.Description,
                    ImageUrl = f.Property.ImageUrl,
                    IsFavorite = true
                }).ToListAsync();
            
            return (properties, totalRecords);
        }

        public async Task<(bool, Favorite?)> IsFavoriteAsync(string userId, Guid propertyId)
        {
            Favorite? favorite = null;
            var res = await _appDbContext.Favorites
                .AnyAsync(f => f.UserId == userId && f.PropertyId == propertyId);
            if (res)
            {
                favorite = await _appDbContext.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.PropertyId == propertyId);
                return (true, favorite);
            }
            return (false, favorite);
        }

    }

}
