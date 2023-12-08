using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> 
    {
        //sorgulanabilir bir liste IQueryAble

        //hepsini getir
        IQueryable<T> FindAll(bool trackChanges);
        
        //bir koşula bağlı olarak getir
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
