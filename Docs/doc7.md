# Entity Framework Core Join işlemleri

Tarih: January 22, 2023 3:59 PM
Tip: KonuNotu

![Untitled](Entity%20Framework%20Core%20Join%20is%CC%A7lemleri%209caf23093ed84abea584487a198da572/Untitled.png)

<aside>
🌟 Inner Join

</aside>

```csharp
var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) =>
    new {
        CategoryName=c.Name,
        ProductName=p.Name,
        ProductPrice=p.Price
    }).ToList();

    result.ForEach(x =>
        {
            Console.WriteLine($" { x.CategoryName} - { x.ProductName} - { x.ProductPrice}");
        });
```

2’den fazla birleştirme için zincir şeklide join kullanılabilir

```csharp
_context.Categories.Join(expression)
.Join(expression)
.Join(expression).ToList(); //birden fazla join işlemi
```

![Untitled](Entity%20Framework%20Core%20Join%20is%CC%A7lemleri%209caf23093ed84abea584487a198da572/Untitled%201.png)

<aside>
🌟 Left/Right Join işlemleri

</aside>

direk ef core üzerinde bu tür sorgular bulunmaz fakat Join() methodu ile sorgu ifadeleri üzerinde işlemler ile yapılabilirler.