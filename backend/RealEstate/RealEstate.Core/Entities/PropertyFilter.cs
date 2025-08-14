using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Entities
{
    public class PropertyFilter
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MaxBedrooms { get; set; }
        public string? Search { get; set; }
        public string? PropertyType { get; set; } // Rent or Sale
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
