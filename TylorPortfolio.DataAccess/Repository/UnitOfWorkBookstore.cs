using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;

namespace TylorTrubPortfolio.DataAccess.Repository
{
    public class UnitOfWorkBookstore : IUnitOfWorkBookstore
    {
        private BookStoreDBContext _bookstoreDb;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWorkBookstore(BookStoreDBContext bookDb)
        {
            _bookstoreDb = bookDb;

            Category = new CategoryRepository(_bookstoreDb);
            Product = new ProductRepository(_bookstoreDb);
        }

        public void Save()
        {
            _bookstoreDb.SaveChanges();        
        }
    }
}
