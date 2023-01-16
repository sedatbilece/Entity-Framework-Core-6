// See https://aka.ms/new-console-template for more information
using EFCORE6.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World! from codefirst");



using (var _context = new AppDbContext())
{
    var producsts = await _context.Products.ToListAsync();

    foreach (var item in producsts)
    {

        var state = _context.Entry(item).State;
        Console.WriteLine($"{item.Id} - {item.Name} - {item.Price} - {item.Stock} - {item.Barcode} - {state}");
    }


    var newProduct = new Product("kalemx",200,1000,"333");

    Console.WriteLine($"state1 : {_context.Entry(newProduct).State}");
    _context.Add(newProduct);
    Console.WriteLine($"state2 : {_context.Entry(newProduct).State}");
    _context.SaveChanges();
    _context.Remove(newProduct);
    _context.SaveChanges();
    Console.WriteLine($"state3 : {_context.Entry(newProduct).State}");


}