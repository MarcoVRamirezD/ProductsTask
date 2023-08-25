using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Product : BaseEntity
    {
        public string productCode {  get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
