using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Purchase : BaseEntity
    {
        public string productName { get; set; }
        public int quantity { get; set; }
    }
}
