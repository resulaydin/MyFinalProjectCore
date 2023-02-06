using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    /* Normalde bu - 
        (X)  public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>
      
       1- Bu yapı(X) işimizi görür diye düşünüyorken Engin hoca imdada yetişti ve 'IProductDal'
       yapısının ise Product ile ayrıca işlemler olacaksa yani ileride sadece Product ile ilgili DB Joinleme
       işlermleri Dto lar tarafından olacaksa sadece X yapısına bağımlı bir durum olmasın diye
       2- Ayrıca bizim SOLID ' de bulunan 'O' kuralına uygun olamsı için yani Business tarafı 'IProductDal' kullanmaktadır
          Dolayısıyla yapının bozulmaması için 'IProductDal' implementasyonunu da yapacaktır. (ÇOOK ÖNEMLİ)
     */
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {

    }
}
