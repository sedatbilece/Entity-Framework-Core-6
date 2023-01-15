// See https://aka.ms/new-console-template for more information
using EFCORE6.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World! from codefirst");



using (var _context = new AppDbContext())
{
    var producsts = await _context.Products.ToListAsync();

    foreach (var item in producsts)
    {
        Console.WriteLine($"{item.Id} : {item.Name} : {item.Price}  {item.Stock}");
    }
}