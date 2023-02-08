using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // Burası sanki veri tabanından veri geliyormuş gibi oldu ancak aslında bellekten verileri çekiyoruz.
            // Test açısından böyle bir kullanım yaptık.( Oracle, Sql Server, Postgres, MongoDb)
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=11,UnitsInStock=15 },
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /* 1- Normalde bu aşağıdaki kod ile listedeki eleman silinir ancak burada silinmez niye (Burası şimdilik kalsın)
              _products.Remove(product);
             */

            /*
             * 2-  Aşağıda eğer productToDelete1 nesnesine değer ataması yapılacaksa bu kodun yazılması memory'i yorar
                Product productToDelete1 = new Product();
            */

            /* 3- 
             
            Product productToDelete=null;


            /*  Eğer link denilen bir teknoloji var bunu bilmezseydim aşağıdaki yorucu işlem yapılacaktı.
             *  Aşağıdaki kodun daha kolay şekilde sanki sql sorgusu yapılıyormuşcasına ( 4- ) 'teki LINQ teknolojisi ile yapılabilir.
             SingleOrDefault(p=>);// Bu aşağıdaki foreach işlevini görmektedir.
            foreach (var productItem in _products)
            {
                if (productItem.ProductID==product.ProductID) {
                    productToDelete = productItem;
                }
            }
            _products.Remove(productToDelete);
            
             */

            // SingleOrDefault() --> bu tek bir eleman bulmaya yarar ve LAMDA(=> (lamda işareti bu)) kullanılacaktır aşağıda
            /* Not : Converting null literal or possible null value to non-nullable type hatasına karşı aşağıda iki yöntem kullanıldı
               Soru  işareti veya sonda ! ünlem kullanıldı.
                1- Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId)!;
                2- Product? productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            */


            Product? productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete ?? new Product());
        }


        public void Update(Product product)
        {
            Product? productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            // Burada where koşulu sağlayan verileri bir liste olarak geri dönderiri.
            // Dikkat devamında " .ToList() " kullanıldı. Çünkü where() fonksiyonu geriye IEnumerable verisi gönderir.
            // " .ToList() " ile bu veri " List " şeklinde Cast oldu.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }



        // Bunlar Generic Repository Design Pattern Haline getirildikten sonra kuruldu.
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }
    }
}
