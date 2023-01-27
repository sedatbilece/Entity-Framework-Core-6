# Entity Framework Core Code First

Tarih: January 15, 2023 7:49 PM
Tip: KonuNotu

entityler oluşturulur ve db üzerinde işlem yapılmaz. İşlemler migrationlar üzerinden yürür.

Connection String içerisinde db ismi vermeye dikkat edilmelidir.

```csharp
Data Source=MATEBOOK-SEDAT\\SQLEXPRESS;initial Catalog=EFCORE6CodeFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
```

<aside>
🌟 Migration

</aside>

`add-migration migAdı`  ile migration oluşturulur. Migrations klasörü içerisinde tutar.

Snapshot ise db ile son migration arasındaki farkları tutmamıza yarayan logical bir dosyadır.

`update-database` diyerek son  migration işleme alınır.

`remove-migration` son yapılan migration’ı siler (db’ye geçmemiş ise)

`update-database migAdı`  ile istenilen migrationa db geri döndürülür .(arkasından istenmeyen `remove-migration` yapılır )