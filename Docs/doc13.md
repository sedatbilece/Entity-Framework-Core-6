# Entity Framework Core Transaction

Tarih: January 27, 2023 10:56 AM
Tip: KonuNotu

`SaveChanges` diyince normalde db ye yansır fakat `transaction` bloğu içerisinde olursa bekletilir ve kaç tane olursa olsun commit satırına gelmeden hata alınırsa otomatik `rollback` yapılır. 

```csharp
using(var transaction = _context.Database.BeginTransaction())
    {
        //işlem 1
        var category = new Category() { Name = "kılıflar" };
        _context.Categories.Add(category);
        _context.SaveChanges();

        //işlem 2
        var prd = new Product()
        {
            Name = "kılıf 1",
            Price = 100,
            Stock = 150,
            Barcode = "123",
            CategoryId = category.Id
        };

        _context.Products.Add(prd);
        _context.SaveChanges();
        transaction.Commit();   
    }
```