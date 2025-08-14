using RealEstate.Core.DTO;
using RealEstate.Core.Entities;

namespace RealEstate.Services
{
    public interface IPropertyService
    {
        Task<(IEnumerable<PropertyDto>, int)> GetFilteredAsync(string? userId, PropertyFilter filter);
        Task<Property?> GetByIdAsync(Guid id);
    }
}
