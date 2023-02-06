using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEntityService<TEntity,TEntityDal> 
        where TEntity : class,IEntity,new()
        where TEntityDal : class,IEntityRepository<TEntity>,new()
    {
       //

    }
}
