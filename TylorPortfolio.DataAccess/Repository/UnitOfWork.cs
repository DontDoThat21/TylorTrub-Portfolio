using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;

namespace TylorTrubPortfolio.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PortfolioDBContext _portfolioDBContext;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IMotorcycleRepository Motorcycle { get; private set; }
        public IMotorcycleVideosRepository MotorcycleVideos { get; private set; }

        public UnitOfWork(PortfolioDBContext bookDb)
        { 
            _portfolioDBContext = bookDb;

            Category = new CategoryRepository(_portfolioDBContext);
            Product = new ProductRepository(_portfolioDBContext);
            Motorcycle = new MotorcycleRepository(_portfolioDBContext);
            MotorcycleVideos = new MotorcycleVideosRepository(_portfolioDBContext);

        }

        public void Save()
        {
            _portfolioDBContext.SaveChanges();        
        }
    }
}
