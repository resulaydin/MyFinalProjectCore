using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add se rvices to the container.

builder.Services.AddControllers();
// Burası yani eğer biri senden IProductService istersen sen ona new ProductManager() oluştur gönder demek
// Yapıyı kurarken neden IProductDal kısmını da yazdık çünkü ProductMAnager,  IProductManager' e loosly coupling 
//  bir yapıya sahip yani yapılandırma derine gidip sonra geliyor ve yukarı doğru kuruyor.
// Buradaki Singleton demek bir milyon container de olsa aynı referansı ver demektir.
// Singleton ne zaman kullanılır -> içerisinde Data tutmayan referanslar bu şekilde kullanılır.
builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal, EfProductDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
