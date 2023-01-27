# Entity Framework Core Indexes (index işlemleri)

Tarih: January 21, 2023 1:18 PM
Tip: KonuNotu

index oluşturmak için annotation ile aşağıdaki yapılabilir.

```csharp
[Index(nameof(Name))]
public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; }
}
```

fluent api ile ise şu şekilde : 

```csharp
//OnModelCreating içinde
modelBuilder.Entity<Product>().HasIndex(x => x.Name);
```

index tablosunda tutulacak ek property(kolon) için ise aşağıdaki şekilde tanımlamayı devam ettirebiliriz.

```csharp
.IncludeProperties(x => x.Price)
```

<aside>
🌟 Decimal için uzunluk sınırlaması

</aside>

```csharp
[Precision(9,2)]// #######.## şeklinde
// ilki toplam karakter sayısı
// ikinci virgülden sonraki karakter sayısı

```

<aside>
🌟 Mantıksal sınırlandırmalar

</aside>

```csharp
modelBuilder.Entity<Product>().HasCheckConstraint("PriceDiscountCheck","[Price]>[DiscountPrice]");
//price indirimli fiyattan büyükmü kontrolü fluent api ile

```