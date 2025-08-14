using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Entities
{
    public class Favorite
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        [ForeignKey("Property")]
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
    }
}
