using System.Linq;
using System.Data.Entity;
namespace DAL
{
    public interface IRepository<T> where T: Models.Base.Entity
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        bool DeleteById(System.Guid id);

        T GetById(System.Guid id);

        //System.Linq.IQueryable<T> Get
        //            (System.Linq.Expressions.Expression<System.Func<T, object>> expression=null);
        System.Collections.Generic.IEnumerable<T> Get
            (System.Linq.Expressions.Expression<System.Func<T, bool>> filter = null,
            System.Func<System.Linq.IQueryable<T>, System.Linq.IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        //System.Linq.IQueryable<T> Get();
        
        bool Save();

        //*****************************************
        
       
    }
}
