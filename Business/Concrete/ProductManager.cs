using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        /// <summary>
        /// public void Add(Product product)
        /// Aşağıdaki bu kod da bulunan void yerine artık IResult geri dönüş değeri kullanıldı.
        /// </summary>
        public IResult Add(Product product)
        {
            //Buraya iş kodları yazılır.


            if (product.ProductName.Length < 2)
            {
                return new ErrorResult("Ürün ismi en az 2 karekter olmalıdır.");
            }

            _productDal.Add(product);
            return new Result(true,"Ürün eklendi.");
        }

        public List<Product> GetAll()
        {
            //İş kodları
            // Yetkisi var mı?
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            return _productDal.GetProductDetailDtos();
        }
    }
}
