using Microsoft.EntityFrameworkCore;
using RealEstate.Core.DTO;
using RealEstate.Core.Entities;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _appDbContext;

        public PropertyRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<(IEnumerable<PropertyDto>, int)> GetFilteredAsync(string? userId,PropertyFilter filter)
        {
            var q = this._appDbContext.Properties.AsQueryable();

            if (filter.MinPrice.HasValue) q = q.Where(p => p.Price >= filter.MinPrice);
            if (filter.MaxPrice.HasValue) q = q.Where(p => p.Price <= filter.MaxPrice.Value);
            if (filter.MinBedrooms.HasValue) q = q.Where(p => p.Bedrooms >= filter.MinBedrooms);
            if (filter.MaxBedrooms.HasValue) q = q.Where(p => p.Bedrooms <= filter.MaxBedrooms);
            if (!string.IsNullOrWhiteSpace(filter.Search)) q = q.Where(p => p.City.Contains(filter.Search) || p.Title.Contains(filter.Search) || p.Description.Contains(filter.Search) || p.Address.Contains(filter.Search));
            if (!string.IsNullOrWhiteSpace(filter.PropertyType)) q = q.Where(p => p.PropertyType == filter.PropertyType);

            var totalRecords = (int)Math.Ceiling((double) await q.CountAsync() / filter.PageSize);
            var properties = await q.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize)
                .Select(p => new PropertyDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Address = p.Address,
                    PropertyType = p.PropertyType,
                    Bedrooms = p.Bedrooms,
                    Bathrooms = p.Bathrooms,
                    CarSpots = p.CarSpots,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    IsFavorite = string.IsNullOrEmpty(userId) ? false : _appDbContext.Favorites.Any(f => f.UserId == userId && f.PropertyId == p.Id) 
                }).ToListAsync();

            return (properties, totalRecords);
        }
        public async Task<Property?> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
