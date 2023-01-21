using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE6.CodeFirst.DAL
{

    [Index(nameof(Name))]
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [Precision(9,2)]// #######.## şeklinde
        public decimal DiscountPrice { get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; }

        public ProductFeature ProductFeature { get; set; }//OnetoOne

        public int CategoryId { get; set; }//relation OnetoMany
        public Category Category { get; set; }//relation

        public Product( string name, decimal price, int stock, string barcode)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Barcode = barcode;
        }

        public Product()
        {
        }
    }
}
