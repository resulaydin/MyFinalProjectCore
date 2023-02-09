using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //1- Eski Yöntem
    //public interface IEntityRepository<T>

    /*
        Aşağıda IEntityRepository interface' sine her önüne gelen önüne geldiği nesneyi atayamasın
        Bu yüzden aşağıdaki şekilde bir sınırlam getirildi.
        // Buradaki : 
        // class   -> Referance Tip olmalı
        // IEntity -> IEntity olabilir veya IEntity implemente eden bir nesne olabilir
        // new()   -> İlgili nesneler new' lenebilir olmalıdır.
                   -> Bunu yapmamızın nedeni IEntity nesnesini ilgili Generic içerisine gönderilmesini engellemek
                   -> Çünkü IEntity interface olduğu için ve interfaceler new' lenemez..
     */
    public interface IEntityRepository<T> where T : class,IEntity,new()
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
