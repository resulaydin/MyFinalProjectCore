using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        /*
            Expression<Func<T,bool>> filter=null
        
        ------------------- Notlar ------------------------------
            * Bu ifade ile GetAll(x) fonksiyonunun x alanına LINQ koşul ifadeleri yazabilmemizi sağlıyor 
            * "filter=null" ifadesinde bu fonksiyonun içerisine filtre vermeyebilirsin demektir. Bu durumda bütün data istenmektedir.
            * 
         */
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T, bool>> filter );
        void Add(T entity); 
        void Update(T entity);
        void Delete(T entity);

        // Yukarıdaki (Expression<Func<T,bool>> filter=null) ifadesi ile aşağıdaki kodu hallediyoruz.
        //List<T> GetAllById(int entityId);
    }
}
