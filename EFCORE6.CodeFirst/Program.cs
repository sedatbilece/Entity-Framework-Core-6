// See https://aka.ms/new-console-template for more information
using EFCORE6.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World! from codefirst");


/*
GetProductPage(2,4).ForEach(x =>
{
    Console.WriteLine($" {x.Name} - {x.Id} ");
});

  static List<Product>  GetProductPage(int page,int pageSize)
{

    using (var _context = new AppDbContext())
    {

        return _context.Products.OrderByDescending(x => x.Id)
                            .Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }
        
}
*/


using (var _context = new AppDbContext())
{

    var list = await _context.ProductFulls.FromSqlRaw("exec sp_get_productFull_param 1 ,100").ToListAsync();

    list.ForEach(x =>
    {
        Console.WriteLine($" {x.Product_Id} - {x.Name} - {x.Price} - {x.CategoryName} ");
    });
    /*
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
     */



    //var prd100 = _context.Products.TagWith("fiyatı 100den yüksek ürünler").Where(x=>x.Price>100).ToList();


    /*
    var prd = _context.ProductEssantials.ToList();


    prd.ForEach(x =>
    {
        Console.WriteLine($" {x.Name} - {x.Price} ");
    });
    */


    /*
    var prd = await _context.Products.FromSqlRaw("select * from Products").ToListAsync();


    //parametre verme işlemi
    var id = 2;
    var prd2 = await _context.Products.FromSqlRaw("select * from Products where id={0}",id).FirstAsync();

    var price = 100;
    var prd3 = await _context.Products.FromSqlRaw("select * from Products where Price > {0}",price).ToListAsync();

    // $ ile içeride değişken ile parametre verme
    var prd4 = await _context.Products.FromSqlRaw($"select * from Products where Price > {price}").ToListAsync();
    */



    /*
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
    */


    //    var ProductFulls = _context.ProductFulls
    //        .FromSqlRaw(@"select p.Id 'Product_Id',c.Name 'CategoryName',p.Name,p.Price,pf.Height
    //from Products p 
    //join ProductFeatures pf on p.Id= pf.Id
    //join Categories c on p.CategoryId = C.Id").ToList();


    //    ProductFulls.ForEach(x =>
    //    {
    //        Console.WriteLine($" { x.Product_Id  } - { x.Name } - { x.CategoryName}");
    //    });


    /* 
     var category = new Category() { Name="Defterler"};

     category.Products.Add(new Product()
     {
         Name = "DEFTER1",
         Price = 100,
         Stock = 150,
         Barcode = "123",
         ProductFeature = new
         ProductFeature()
         { Color = "red", Width = 100, Height = 100 }
     });
     category.Products.Add(new Product()
     {
         Name = "DEFTER2",
         Price = 200,
         Stock = 300,
         Barcode = "456",
         ProductFeature = new
         ProductFeature()
         { Color = "green", Width = 100, Height = 100 }
     });
     category.Products.Add(new Product()
     {
         Name = "DEFTER3",
         Price = 300,
         Stock = 450,
         Barcode = "789",
         ProductFeature = new
         ProductFeature()
         { Color = "blue", Width = 100, Height = 100 }
     });

     _context.Categories.Add(category);
     _context.SaveChanges();
     Console.WriteLine("işlem bitti");


 }
 */


    /*
    using (var _context = new AppDbContext())

    {

        var category = new Category() { Name = "Kalemler" };

        var product = new Product () { Name="kalem1",Price=100,Stock=0,Barcode= "123" };
        product.Category = category;

        _context.Add(product);
        _context.SaveChanges();


        var producsts = await _context.Products.AsNoTracking().ToListAsync();

        foreach (var item in producsts)
        {
            item.Stock += 100;
            var state = _context.Entry(item).State;
            Console.WriteLine($"{item.Id} - {item.Name} - {item.Price} - {item.Stock} - {item.Barcode} - {state}");
        }
        _context.SaveChanges();


        var newProduct = new Product("kalemx",200,1000,"333");

        Console.WriteLine($"state1 : {_context.Entry(newProduct).State}");
        _context.Add(newProduct);
        Console.WriteLine($"state2 : {_context.Entry(newProduct).State}");
        _context.SaveChanges();
        Console.WriteLine($"state3 : {_context.Entry(newProduct).State}");


        //var prd = _context.Products.First(x => x.Id>100);//return exception
        var prd2 = _context.Products.FirstOrDefault(x => x.Id>100);//return null
        var prd3 = _context.Products.Single(x => x.Id == 7);//return prd 7
        var prd4 = _context.Products.Where(x => x.Id > 4).ToList();// return 5,6,7 id data
        var prd5 = _context.Products.Find(5);//return prd id 5
    }
    */
}