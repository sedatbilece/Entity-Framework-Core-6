# Entity Framework Core Projection

Tarih: January 25, 2023 10:08 AM
Tip: KonuNotu

<aside>
🌟 Anonymous Type

</aside>

veriyi bilinmeyen tipte tutma işlemi

```csharp
var anonymous = _context.Products.Include(x => x.Category).Select(x => new
    {
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price

    }).Where(y=> y.ProductPrice>100).ToList();

    // ToList() ile db den veri getirilir yazılmaz ise sorgu işlemi yapılmaz

    anonymous.ForEach(x =>
    {
        Console.WriteLine($" {x.CategoryName} - {x.ProductName} - {x.ProductPrice}");
    });
```

<aside>
🌟 Manuel Dto ( Elle Mapleme)

</aside>

```csharp
var anonymous = _context.Products.Include(x => x.Category).Select(x => new ProductDto
    {
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price

    }).Where(y=> y.ProductPrice>100).ToList();

    // ToList() ile db den veri getirilir yazılmaz ise sorgu işlemi yapılmaz

    anonymous.ForEach(x =>
    {
        Console.WriteLine($" {x.CategoryName} - {x.ProductName} - {x.ProductPrice}");
    });
```

<aside>
🌟 Dto AutoMapper

</aside>

```csharp
//program.cs içinde
var prd = _context.Products.ToList();

    var prdDto =ObjectMapper.Mapper.Map<List<ProductDto>>(prd);
```

```csharp
//ObjectMapper.cs (config classı içinde)

namespace EFCORE6.CodeFirst.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }

    internal class CustomMapping : Profile
    {
        public CustomMapping() { 
                CreateMap<Product, ProductDto >().ReverseMap();
        }
    }
}
```