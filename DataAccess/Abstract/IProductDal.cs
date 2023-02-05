using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{ 

    // Burası veritabanı ile ilgili operasyonların yazılacağı interface
    public interface IProductDal:IEntityRepository<Product>
    {


        /*
         * 1. Yöntem (Eski) 
         
        List<Product> GetAll();
        List<Product> GetAllByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        */
    }
}
