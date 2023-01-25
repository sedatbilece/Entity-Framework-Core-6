using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE6.CodeFirst.DTOs
{
    public class ProductDto
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
