using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Concurrency.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await  _context.Products.FindAsync(id);


            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(List));

            }
            catch(DbUpdateConcurrencyException ex )
            {
                var expEntry = ex.Entries.First();
                var currentProduct = expEntry.Entity as Product;
                
                var clientValues = expEntry.CurrentValues;

                var databaseValues = expEntry.GetDatabaseValues();

                var databaseProduct = databaseValues.ToObject() as Product;

                if (databaseValues == null)
                {
                    ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından silindi");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından güncellendi");
                }
                return View(product);
            }
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.Products.ToListAsync() );
        }


    }
}
