using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    /* Neden X ,IProductDal şeklinde bir kullanım yapmalıyız.
     * (X)  public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>
      
       1- Bu yapı(X) işimizi görür diye düşünüyorken Engin hoca imdada yetişti ve 'IProductDal'
       yapısının ise Product ile ayrıca işlemler olacaksa yani ileride sadece Product ile ilgili DB Joinleme
       işlermleri Dto lar tarafından olacaksa sadece X yapısına bağımlı bir durum olmasın diye
       2-   Ayrıca bizim SOLID ' de bulunan 'O' kuralına uygun olamsı için yani Business tarafı 'IProductDal' kullanmaktadır
          Dolayısıyla yapının bozulmaması için 'IProductDal' implementasyonunu da yapacaktır. (ÇOOK ÖNEMLİ)
       3-   Ayrıca tablo olmayan Join verilerinin oluşturulması için DTOs klasörü ve buna bağlı sınıflar, interfaces ler oluş
          turuldu. Aşağıda IPorductDal üzerinden bu verilere erişim sağlandı.
     */
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             { // Aşağıda yazılanlar ProductDetailDto entity' sindeki attribute' lere denk gelmelidir.
                                 ProductId =p.ProductId,
                                 ProductName=p.ProductName,
                                 CategoryName=c.CategoryName,
                                 UnitsInStock=p.UnitsInStock
                             };
                return result.ToList();

            }
        }
    }

    /* -------------------------- Bu Eski Yöntem --------------------------------------------


    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
            using NorthwindContext context = new NorthwindContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            using NorthwindContext context = new NorthwindContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using NorthwindContext context = new NorthwindContext();
            return context.Set<Product>().SingleOrDefault(filter) ?? new Product();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using NorthwindContext context = new NorthwindContext();
            return filter == null
                ? context.Set<Product>().ToList()
                : context.Set<Product>().Where(filter).ToList();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
    */
}
