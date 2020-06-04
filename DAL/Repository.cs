using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
namespace DAL
{
    public class Repository<T> : IRepository<T> where T : Models.Base.Entity
    {

        //************************************************************
        protected System.Data.Entity.DbSet<T> DbSet { get; set; }
        protected Models.DatabaseContext DatabaseContext { get; set; }

        public Repository(Models.DatabaseContext databaseContext)
        {
            if (databaseContext==null)
            {
                databaseContext = new Models.DatabaseContext();
            }

            DatabaseContext = databaseContext;
            DbSet = databaseContext.Set<T>();
        }
        //************************************************************

        public bool Insert(T entity)
        {
            try
            {
                DbSet.Add(entity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                DbSet.Attach(entity);
                DatabaseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                if (DatabaseContext.Entry(entity).State==EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }

                DbSet.Remove(entity);

                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        //*****************************************

        public bool DeleteById(System.Guid id)
        {
            try
            {
                var theEntity = GetById(id);
                Delete(theEntity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public T GetById(System.Guid id)
        {
            T theEntity = DbSet
                        .Where(current => current.Id == id)
                        .FirstOrDefault();

            return (theEntity);
        }

        //*****************************************

        //public System.Linq.IQueryable<T> Get(System.Linq.Expressions.Expression<System.Func<T,object>> expression = null)
        //{
        //    var allUsers = DbSet.Include(current=>current);
        //    return (allUsers);
        //} 

        //This code Need to Impreove
        public virtual System.Collections.Generic.IEnumerable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }


        //public System.Linq.IQueryable<T> Get()
        //{
        //    var allEntity = DbSet.ToList();
        //    return allEntity;
        //}


        //*****************************************
        public bool Save()
        {
            try
            {
                DatabaseContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        //*****************************************
        

       
    }
}
