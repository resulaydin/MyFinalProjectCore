
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // 2.1 Yöntem 
        // Bu yapıya ' Loosely Coupled '  denir
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]   
        public List<Product> Get()
        {
            /*  1. Yöntem - Sorun: Bir Dependency Chain vardı ve 
                    IProductService productService = new ProductManager(new EfProductDal()); 
                kodumuzda Get() metodumuzun bir ProductManager sınıfına bağımlı olduğunu gördük
                Nasıl ki ProductManager içerisinde problemi IProductDal CTOR ederek genel bir referans oluşturduk
                aynı şekilde burada da bir IProductService CTOR nesnesi injection etmeliyiz.
                
             */

            //2.2 Yöntem - Biz bu haldeyken çalıştırdığımızda hata verecek çünkü biz yukarıdaki 
            // CTOR kısmını herhangi bir yerde çağırmadık. Dolayısıyla işte burada 
            // IoC (Inversion of Control) Container 
            var result= _productService.GetAll();
            return result.Data;
        }
    }
}
