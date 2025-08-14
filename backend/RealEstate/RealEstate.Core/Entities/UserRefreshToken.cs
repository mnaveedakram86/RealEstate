using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Entities
{
    public class UserRefreshToken
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        public string UserId { get; set; } = null!;

        public string RefreshToken { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
