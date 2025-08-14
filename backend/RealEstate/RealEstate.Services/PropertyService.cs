using RealEstate.Core.DTO;
using RealEstate.Core.Entities;
using RealEstate.Infrastructure.Repositories;

namespace RealEstate.Services
{
    public class PropertyService : IPropertyService
    {
        public readonly IPropertyRepository _propertyRepository;
        public PropertyService(IPropertyRepository propertyRepository)
        {
            this._propertyRepository = propertyRepository;
        }

        public async Task<(IEnumerable<PropertyDto>, int)> GetFilteredAsync(string? userId,PropertyFilter filter)
        {
            return await this._propertyRepository.GetFilteredAsync(userId, filter);
        }
        public async Task<Property?> GetByIdAsync(Guid id)
        {
            return await this._propertyRepository.GetByIdAsync(id);
        }
    }
}