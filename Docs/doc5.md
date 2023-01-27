# Entity Framework Core Entity Davranışları

Tarih: January 19, 2023 10:44 AM
Tip: KonuNotu

<aside>
🌟 Table-Per-Hierarchy

</aside>

```csharp
public class BasePerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

public class Employee : BasePerson
    {
        public decimal Salary { get; set; }
    }
public class Manager : BasePerson
    {
        public int Grade { get; set; }
    }
```

eğer app dbde `Employee` ve `Manager`  verilirse 2 ayrı tablo oluşturur ve base persondaki kolonları aynı şekil bunlarada ekler

```csharp
public DbSet<Manager> Managers { get; set; }
public DbSet<Employee> Employees { get; set; }
```

<aside>
🌟 Birleştirilmiş yapı  Table-Per-Hierarchy

</aside>

Aşağıdaki şekilde `BasePerson` eklenrise AppDbContext içine 

```csharp
public DbSet<BasePerson> Persons{ get; set; }
public DbSet<Manager> Managers { get; set; }
public DbSet<Employee> Employees { get; set; }
```

`Employee` ve `Manager`  daki kolonları `Person` tablosuna ekler ve `Ayırıcı` bir kolon ile 2 tabloyu birleştirir

![ss1.png](Entity%20Framework%20Core%20Entity%20Davran%C4%B1s%CC%A7lar%C4%B1%20fcdd6e680fe548a6bfc0fd1b5e4ac88a/ss1.png)

<aside>
🌟 Table-Per-Type

</aside>

tabloların hiyerşiden etkilenmeden oluşturulmasını istersek 

```csharp
//onModelCreating içerisinde

modelBuilder.Entity<BasePerson>().toTable("Persons");
modelBuilder.Entity<Manager>().toTable("Managers");
modelBuilder.Entity<Employee>().toTable("Employees");
```

şeklinde tanımlanırsa sadece kendi içlerindeki  proplara göre oluşturulurlar.(istisna Id kolonu eklenir)

Burada Person ile bunlar arasında otomatik ilişki kurar.

<aside>
🌟 Owned Entities

</aside>

`[Owned]` annotation ile uygulanır.

![ss2.png](Entity%20Framework%20Core%20Entity%20Davran%C4%B1s%CC%A7lar%C4%B1%20fcdd6e680fe548a6bfc0fd1b5e4ac88a/ss2.png)

Sonucunda default şu şekilde tablolar oluşur:

![ss3.png](Entity%20Framework%20Core%20Entity%20Davran%C4%B1s%CC%A7lar%C4%B1%20fcdd6e680fe548a6bfc0fd1b5e4ac88a/ss3.png)

<aside>
🌟 Keyless Entity and Raw Query

</aside>

![ss1.png](Entity%20Framework%20Core%20Entity%20Davran%C4%B1s%CC%A7lar%C4%B1%20fcdd6e680fe548a6bfc0fd1b5e4ac88a/ss1%201.png)

```csharp
var ProductFulls = _context.ProductFulls
        .FromSqlRaw(@"select p.Id 'Product_Id',c.Name 'CategoryName',p.Name,p.Price,pf.Height
from Products p 
join ProductFeatures pf on p.Id= pf.Id
join Categories c on p.CategoryId = C.Id").ToList();

    ProductFulls.ForEach(x =>
    {
        Console.WriteLine($" { x.Product_Id  } - { x.Name } - { x.CategoryName}");
    });

//          ------ ENTITY ------

    [Keyless]
    public  class ProductFull
    {
        public int Product_Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal  Price { get; set; }
        public int Height { get; set; }
    }
```

<aside>
🌟 Entity Properties

</aside>

`[NotMapping]` : entity üzerindeki prop’u veritabanına kolon olarak eklemez.

`[Column(”Name”)]`  :  Kolona özel isim vermemizi sağlar.

`[Column(TypeName=”Nvarchar(200)”)]` : kolon tipi belirlememizi sağlar.

`[Unicode(false)]`  :  varchar veri tutar , kısa stringler için kullanılabilir.