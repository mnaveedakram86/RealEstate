using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Entities
{
    public class Property
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;      

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public string PropertyType { get; set; } = "Sale"; // "Rent" or "Sale"
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpots { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
