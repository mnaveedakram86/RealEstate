using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.DTO
{
    public class PagedResultDto<T>
    {
        public IEnumerable<T> Listing { get; set; }
        public int TotalRecords { get; set; }
    }
}
