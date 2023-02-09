using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        /// <summary>
        /// IDataResult<List<Product>>
        /// Daha önce yukarıdaki kod List<Product> idi artık geri dönüş değeri yuukarıdaki gibi oldu hepsinin
        /// </summary>
        /// <returns></returns>
        IDataResult<List<Product>>  GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetailDtos();

        IDataResult<Product> GetById(int productId);

        /// <summary>
        /// void Add(Product product);
        /// Aşağıdaki bu kod da bulunan void yerine artık IResult geri dönüş değeri kullanıldı.
        /// </summary>
        /// Ayrıca aşağıdaki IDataResult<List<Product>>  yapılmadı çünkü bu 'void' geri dönüş değerini temsil edecektir.
        IResult Add(Product product);

    }
}
