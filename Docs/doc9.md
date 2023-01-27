# Entity Framework Core Pagination (Skip ve Take Methodları)

Tarih: January 23, 2023 11:22 AM
Tip: KonuNotu

```csharp

  static List<Product>  GetProductPage(int page,int pageSize)
{

    using (var _context = new AppDbContext())
    {

        return _context.Products.OrderByDescending(x => x.Id)
                   .Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }
        
}

GetProductPage(2,4).ForEach(x =>
{
    Console.WriteLine($" {x.Name} - {x.Id} ");
});
```