# Entity Framework Core Database First

Tarih: January 14, 2023 7:29 PM
Tip: KonuNotu

ilk önce veritabanında tablolar oluşturulur.

AppDbContext adında dosya oluşturup içerisinde DbSetler oluşturuyorum

AppDbContext : Database

DbSet : Table şeklinde karşılık gelmektedir.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE6.DatabaseFirst.DAL
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MATEBOOK-SEDAT\\SQLEXPRESS;Initial Catalog=EFCORE-DatabaseFirstDb;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");    
        }
    }
}
```

ConnectionString için `SqlServerObjectExplorer`   db  üzerinden properties deyip alınabilir(vs içinde )

database elle oluşturulduktan sonra karşılık gelen entityler elle oluşturulabilir yada 

`Scaffold DbContext Auto Generation` diye bir yol ile yapılabilir. (BÖLÜM2 , Ders11)