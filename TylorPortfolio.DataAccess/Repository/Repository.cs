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
        public Repository(DbContext db)
        {
            try
            {
                _bookStoreDBContext = (BookStoreDBContext?)db;
                this.dbSet = _bookStoreDBContext.Set<T>();
                _bookStoreDBContext.Products.Include(u => u.Category).Include(u => u.CategoryId);
            }
            catch (Exception)
            {
            }
            try
            {
                _motorcycleDBContext = (MotorcycleDBContext?)db;
                this.dbSet = _motorcycleDBContext.Set<T>();
            }
            catch (Exception)
            {
            }
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        // Category, CategoryId
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
        
    }
}
