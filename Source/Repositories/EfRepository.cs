using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class EfRepository<T> : IDataRepository<T> where T : class
    {
        private readonly DbContext _context;

        private DbSet<T> _entities;

        public EfRepository(ApplicationContext context)
        {
            this._context = context;
        }

        #region Methods

        public int Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Remove(entity);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Update(entity);
            var res = this._context.SaveChanges();
            return res;
        }

        public T Get(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return Entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        #endregion

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking => this.Entities.AsNoTracking();

        /// <summary>
        /// Get a table
        /// </summary>
        public virtual IQueryable<T> Table => this.Entities;

        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
    }
}
