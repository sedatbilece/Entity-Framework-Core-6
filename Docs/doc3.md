# Entity Framework Core DbContext

Tarih: January 16, 2023 6:43 PM
Tip: KonuNotu

![ss1.png](Entity%20Framework%20Core%20DbContext%2084588e82a2094135b88e9fa2dc3a1e4e/ss1.png)

Nesne üzerinde 5 temel state bulunur 

- Added:
- Deleted:
- **Detached:** efcore tarafından takip edilmez
- Modified:
- **UnChanged:** db’den data alınıp güncelleme yapılmazsa unchanged atama yapar

<aside>
🌟 `_context.Entry(newProduct).State` ile nesnenin statei öğrenebiliriz

</aside>

```csharp
var newProduct = new Product("kalemx",200,1000,"333");

    Console.WriteLine($"state1 : {_context.Entry(newProduct).State}");
    _context.Add(newProduct);
    Console.WriteLine($"state2 : {_context.Entry(newProduct).State}");
    _context.SaveChanges();
    Console.WriteLine($"state3 : {_context.Entry(newProduct).State}");
```

 state1 : Detached

state2 :  Added

state3 : Unchanged

<aside>
🌟 DbContext Property

</aside>

ChangeTracker , ContextId , Database 

`ChangeTracker` : bellekte takip edilen entity’lere erişim ve değiştirme imkanı sağlar.

‼️ Eğer getirilen datanın boyutu fazla ise bellekte takip edilmesin isteniyor ise `.AsNoTracking().ToListAsync();`  şeklinde kullanılabilir.

<aside>
🌟 DbSet<>

</aside>

- Add/AddAsync
- Update
- Remove
- Single
- Where

- AsNoTracking
- Find/FindAsync
- FirstOrDefault
- SingleOrDefault

<aside>
🌟 Entity Configuration

</aside>

convensions defaultta isimlendirmelerden efcore’un otomatik olarak propertyleri algılaması demektir .

![ss2.png](Entity%20Framework%20Core%20DbContext%2084588e82a2094135b88e9fa2dc3a1e4e/ss2.png)

entityleri kirletmemek için `fluent api` kullanılabilir(dbcontext classı içinde )

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Product>().ToTable("ProductTb", "products");
   }
```

‼️ `Annotation`’lar ile hem db hemde validation yapılır `fluent api`’den farklı olarak