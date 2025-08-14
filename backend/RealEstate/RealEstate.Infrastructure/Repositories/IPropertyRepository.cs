using RealEstate.Core.DTO;
using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public interface IPropertyRepository
    {
        Task<(IEnumerable<PropertyDto>,int)> GetFilteredAsync(string? userId,PropertyFilter filter);
        Task<Property?> GetByIdAsync(Guid id);
    }
}
