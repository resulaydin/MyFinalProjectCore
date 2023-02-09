using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            // Yetkisi var mı?
            /*return _productDal.GetAll();
                Burası IDataResult<List<Product>> yapılınca kızardı. Bu yüzden geri dönüş
                değeri ile bilrlikte aşağıdaki gibi bir new IDataResult<List<Product>>(_productDal.GetAll());
                yazılarak sonuç halledildir. Çünkü metedumuz bir IDataResult olan geri dönüş istemektedir.
            */

            return new DataResult<List < Product >>(_productDal.GetAll()),true,"Ürünler listelendi");    
        }

        public IDataResult<List<Product>>  GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public IDataResult<List<Product>>  GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            return _productDal.GetProductDetailDtos();
        }
    }
}
