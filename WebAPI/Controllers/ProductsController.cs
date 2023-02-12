
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

        // 2.4. Yöntem
        // [HttpGet]
        [HttpGet("getall")]
        /*//1.1 Yöntem -
             public List<Product> Get()
             {
                    var result= _productService.GetAll();
                    return result.Data;
             }
        */

        // 2.3 Yöntem işin içerisine artık httpStatus control girecek
        public IActionResult  Get()
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
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        /* Hata: The request matched multiple endpoints. Matches: 
            şeklinde Postman tarafında haklı olarak sunucu bir hata verdiğinden dolayı biz problemi çözmek adına
            [HttpGet("getall")], [HttpGet("getbyid")] ,[HttpPost("add")]

        Daha sonra gidip bizim url' nin sonuna işte bu allians ları kullanacağız.
        https://localhost:---/api/products/getall
        
        denirse yukarıdaki [HttpGet] -> "getall" çalışır

         
         */
    }
}
