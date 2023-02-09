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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetByUnitPrice(decimal min, decimal max);

        List<ProductDetailDto> GetProductDetailDtos();

        Product GetById(int productId);

        /// <summary>
        /// void Add(Product product);
        /// Aşağıdaki bu kod da bulunan void yerine artık IResult geri dönüş değeri kullanıldı.
        /// </summary>
        IResult Add(Product product);

    }
}
