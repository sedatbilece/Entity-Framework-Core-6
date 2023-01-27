# Entity Framework Core Stored Procedure

Tarih: January 24, 2023 10:34 AM
Tip: KonuNotu

sql cümleciği yazıldıktan sonra derlenir ve execution plan oluşturulur . ham sql sorgularında sorgu aynı olsa bile tekrar tekrar bu işlem uygulanır.

`Stored procedure`’de ise bu işlem oluşturulurken yapılır ve bir daha tekrarlanmaz.

### sql server üzerinde kod

```sql
create procedure sp_get_products
as
begin
     select * from Products
end
-- programmability> Stored Procedures klasöründe oluşur

-- çalıştırma işlemi
exec sp_get_products
```

burada yazılan sorgudan dönen değerler entity tarafında aynı değerlere sahip class ile karşılanmalıdır. 

`Eğer procedure içindeki kolon isimleri ile entity isimlerinde bir tanesi bile uyuşmaz ise hata fırlatır.`

### .Net üzerinde kullanımı

```csharp
var list = await _context.Products
   .FromSqlRaw("exec sp_get_products").ToListAsync();
```

<aside>
🌟 Join ile birden fazla tablo birleşimi

</aside>

```sql
create procedure sp_get_productFull
as
begin
     select p.Id 'Product_Id',p.Name,c.Name 'CategoryName',p.Price,pf.Height from Products p
	 join Categories c on p.CategoryId=c.Id
	 join  ProductFeature pf on p.Id=pf.Id

end
-- programmability> Stored Procedures klasöründe oluşur

-- çalıştırma işlemi
exec sp_get_productFull
```

### .net üzerinde

aşağıdaki class kullanılacak primary key almadığı belirtilmesi gerekli ve 

`AppDbContext`’e `DbSet`’i eklenmelidir.

```csharp
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
🌟 Parametre Verme İşlemi

</aside>

```sql
create procedure sp_get_productFull_param
@categoryId int,
@price decimal(9,2)
as
begin
     select p.Id 'Product_Id',p.Name,c.Name 'CategoryName',p.Price,pf.Height from Products p
	 join Categories c on p.CategoryId=c.Id
	 join  ProductFeature pf on p.Id=pf.Id
	 where p.CategoryId=@categoryId and p.Price >@price

end
-- programmability> Stored Procedures klasöründe oluşur

-- çalıştırma işlemi
exec sp_get_productFull_param 1 ,100
```

### .Net üzerinde stringi yazmak yeterli işlem aynı