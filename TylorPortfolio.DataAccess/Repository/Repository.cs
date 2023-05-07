using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;

namespace TylorTrubPortfolio.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookStoreDBContext _bookStoreDBContext;
        internal DbSet<T> dbSet;
        private readonly MotorcycleDBContext _motorcycleDBContext;

        /// <summary>
        /// The motorcycle and bookstore DBs are seperated intentionally.
        /// I don't see why they would logically be connected. Also, I like the challenge of
        /// juggling two context and seeing how .NET Core 8 handles it. Seems good!
        /// </summary>
        /// <param name="book">BookStore and categories DB.</param>
        /// <param name="motorcycle">Motorcycle store, information, and CDN DB.</param>        
        public Repository(DbContext _db)
        {
            try
            {
                _bookStoreDBContext = (BookStoreDBContext?)_db;
                this.dbSet = _db.Set<T>();
            }
            catch (Exception)
            {
            }
            try
            {
                _motorcycleDBContext = (MotorcycleDBContext?)_db;
                this.dbSet = _db.Set<T>();
            }
            catch (Exception)
            {
            }
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }        

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
