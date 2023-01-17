// See https://aka.ms/new-console-template for more information
using EFCORE6.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World! from codefirst");



using (var _context = new AppDbContext())
{
    var producsts = await _context.Products.AsNoTracking().ToListAsync();

    foreach (var item in producsts)
    {
        item.Stock += 100;
        var state = _context.Entry(item).State;
        Console.WriteLine($"{item.Id} - {item.Name} - {item.Price} - {item.Stock} - {item.Barcode} - {state}");
    }
    _context.SaveChanges();


    var newProduct = new Product("kalemx",200,1000,"333");

    Console.WriteLine($"state1 : {_context.Entry(newProduct).State}");
    _context.Add(newProduct);
    Console.WriteLine($"state2 : {_context.Entry(newProduct).State}");
    _context.SaveChanges();
    Console.WriteLine($"state3 : {_context.Entry(newProduct).State}");

    
    //var prd = _context.Products.First(x => x.Id>100);//return exception
    var prd2 = _context.Products.FirstOrDefault(x => x.Id>100);//return null
    var prd3 = _context.Products.Single(x => x.Id == 7);//return prd 7
    var prd4 = _context.Products.Where(x => x.Id > 4).ToList();// return 5,6,7 id data
    var prd5 = _context.Products.Find(5);//return prd id 5

    

}