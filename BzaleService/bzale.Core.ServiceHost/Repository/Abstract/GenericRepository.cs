using bzale.Model.Base;
using bzale.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bzale.Repository.Abstract
{
    public abstract class GenericRepository<T>  where T : Entity 
    {
        private BzaleDatabaseContext _entities;
        public GenericRepository(BzaleDatabaseContext context)
        {
            _entities = context;
        }

        //public BzaleDatabaseContext Context
        //{

        //    get { return _entities; }
        //    set { _entities = value; }
        //}

        //protected IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        //{

        //    IQueryable<T> query = _entities.Set<T>().Where(predicate);
        //    return query;
        //}
        protected IQueryable<T> Get(Expression<Func<T, bool>> predicate,int page, int size)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate).OrderBy(e=>e.ID).Skip(page*size).Take(size);
            return query;
        }
        protected T GetSingle(Expression<Func<T, bool>> predicate)
        {
            T query = _entities.Set<T>().Where(predicate).FirstOrDefault();
            return query;

        }

        protected virtual void Add(T entity)
        {
            entity.Created = DateTime.Now;
            _entities.Set<T>().Add(entity);
        }

        protected virtual void Delete(T entity)
        {
            entity.Deleted = DateTime.Now;
            _entities.Set<T>().Remove(entity);
        }
        public virtual void Delete(int entityid)
        {
            var entity = GetSingle(e => e.ID == entityid);
            entity.Deleted = DateTime.Now;
            _entities.Set<T>().Remove(entity);
        }

        protected virtual void Edit(T entity)
        {
            entity.Updated = DateTime.Now;
            entity.Deleted = null;
            
            _entities.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void Save()
        {
            _entities.SaveChanges();
        }

        protected virtual void SaveAsync()
        {
            _entities.SaveChangesAsync();
        }
    }
}
