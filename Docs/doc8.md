# Entity Framework Core Raw Query

Tarih: January 22, 2023 4:51 PM
Tip: KonuNotu

```csharp
var prd = await _context.Products
.FromSqlRaw("select * from Products").ToListAsync();

    //parametre verme işlemi
    var id = 2;
    var prd2 = await _context.Products
.FromSqlRaw("select * from Products where id={0}",id).FirstAsync();

    var price = 100;
    var prd3 = await _context.Products
.FromSqlRaw("select * from Products where Price > {0}",price).ToListAsync();

    // $ ile içeride değişken ile parametre verme
    var prd4 = await _context.Products
.FromSqlRaw($"select * from Products where Price > {price}").ToListAsync();
```

<aside>
🌟 Raw sorguda farklı entity ile tutma işlemi

</aside>

```csharp
public class ProductEssantial
    {

        public string Name { get; set; }
        public string Price { get; set; }
    }
// context içinde key(id) tutulmadığı belirtimeli
modelBuilder.Entity<ProductEssantial>().HasNoKey()
.ToSqlQuery("select Name,Price from Products");
```

artık bu ProductEssantial üzerinden sorgu yazdığımda temel olarak buraya yazılan sorguyu çalıştırıcak 

```csharp
var prd = _context.ProductEssantials.ToList();

    prd.ForEach(x =>
    {
        Console.WriteLine($" {x.Name} - {x.Price} ");
    });
```