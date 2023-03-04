using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TactSoft.Core.Interface.Base;
using TactSoft.Core.Model.Base;
using TactSoft.Data.Data;

namespace TactSoft.Data.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly ApplicationDb _db;
        private readonly DbSet<T> entites;
        public BaseRepository(ApplicationDb db)
        {
            _db = db;
            entites = _db.Set<T>();
        }
        public IQueryable<T> All()
        {
            return entites.Where(x =>! x.IsDelete);
        }

        public IQueryable<T> All(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = All();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        public void Delete(T entity)
        {
            if (entity==null)
            {
                throw new NotImplementedException("entity");
            }
            entites.Remove(entity);
            _db.SaveChanges();
        }

        public T Find(long id)
        {
            return entites.SingleOrDefault(x=>x.Id==id);
        }

        public T Find(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreateDate = DateTime.UtcNow;
            entity.UpdateDate = DateTime.UtcNow;
            entites.Add(entity);
            _db.SaveChanges();
        }

        public void Update(T entity, int id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            T exist = _db.Set<T>().Find(id);
            if (exist != null)
            {
                _db.Entry(exist).CurrentValues.SetValues(entity);
                _db.SaveChanges();
            }
            _db.SaveChanges();
        }
    }
}
