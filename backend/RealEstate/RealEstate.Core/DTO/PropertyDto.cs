using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.DTO
{
    public class PropertyDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal Price { get; set; }
        public string PropertyType { get; set; } = null!;
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpots { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool IsFavorite { get; set; } 
    }
    
}
