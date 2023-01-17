using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE6.CodeFirst.DAL
{
    public class ProductFeature
    {

        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        // use foreign key in child relation
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
