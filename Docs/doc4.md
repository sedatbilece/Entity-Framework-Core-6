# Entity Framework Core Relationships

Tarih: January 17, 2023 9:14 AM
Tip: KonuNotu

<aside>
🌟 One to Many

</aside>

```csharp
public class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public List<Product> Products { get; set; }
    }
```

```csharp
public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; }

        public int CategoryId { get; set; }//relation
        public Category Category { get; set; }//relation
}
```

<aside>
🌟 One to One

</aside>

```csharp
public class ProductFeature
    {

        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        // use foreign key in child relation
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
```

```csharp
public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; }

        public ProductFeature ProductFeature { get; set; }//OnetoOne
}
```

<aside>
🌟 Many to Many

</aside>

```csharp
public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
```

```csharp
public class Student
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int Age { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
```

<aside>
🌟 Delete Behaviors

</aside>

 örnğin bire çok bir ilişkide category ve product tabloları olsun

- **(Def)Cascade :** category silinirse category’e bağlı productlar silinir.
- **Restrict :** categoryi silmek istersek ona bağlı product varsa silinmesini engeller.
- **SetNull :** product içindeki CategoryId NULL alabiliyorsa category silinince ilgili productların CategoryId’lerine null atar.
- **NoAction :**  database üzerinden ayarlamayı sağlar efcore işlem yapmaz.

davranışı fluent api üzerinden şöyle yapabiliriz.

```csharp
modelBuilder.Entity<Category>()
.OnDelete(DeleteBehavior.Cascade)
```

<aside>
🌟 Eager Loading

</aside>

include methodu ile category’E bağlı product eager loading ile direk category çekilirken yüklenir

```csharp
var categoryWithProduct = 
_context.Categories.Include(x ⇒ x.Product ).First()
```

<aside>
🌟 Explicit Loading

</aside>

Arada bir yerde lazım olursa product çekmek istersek bu yöntemi kullanmalıyız.

```csharp
_context.Entry(category).Collection(x => x.Product).Load()
```

<aside>
🌟 Lazy Loading

</aside>

category’nin product propertysine erişirsek db’ye arka planda tekrar gider ve yükler.

```csharp
var category = _context.categories.First();
var products = category.**Products**
```

EF Core Proxies yüklenmeli bunun için

aynı zamanda lazy loading configuration yapılmalıdır.