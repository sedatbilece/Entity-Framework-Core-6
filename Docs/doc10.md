# Query Loglama

Tarih: January 23, 2023 12:00 PM
Tip: KonuNotu

AppDbContext içerisinde şunu ekliyoruz

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
  optionsBuilder.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information)
       .UseSqlServer("Data source link");
}
```

![Untitled](Query%20Loglama%20aa685b2a88dd4da28c14cb3674e5a6f2/Untitled.png)

yukarıdaki açıklama için ise işlemlerden önce  `.TagWith()` ile tagini yazıyoruz

```csharp
var prd100 = _context.Products
.TagWith("fiyatı 100den yüksek ürünler").Where(x=>x.Price>100).ToList();
```