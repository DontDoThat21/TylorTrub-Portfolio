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
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IMotorcycleVideosRepository MotorcycleVideos { get; private set; }
        public IPortfolioImagesRepository PortfolioImages { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IGamesRepository Games { get; private set; }

        public UnitOfWork(PortfolioDBContext portfolioDb)
        { 
            _portfolioDBContext = portfolioDb;

            Category = new CategoryRepository(_portfolioDBContext);
            Product = new ProductRepository(_portfolioDBContext);
            Motorcycle = new MotorcycleRepository(_portfolioDBContext);
            ShoppingCart = new ShoppingCartRepository(_portfolioDBContext);
            ApplicationUser = new ApplicationUserRepository(_portfolioDBContext);
            MotorcycleVideos = new MotorcycleVideosRepository(_portfolioDBContext);
            PortfolioImages = new PortfolioImageRepository(_portfolioDBContext);
            Company = new CompanyRepository(_portfolioDBContext);
            Games = new GamesRepository(_portfolioDBContext);

        }

        public void Save()
        {
            _portfolioDBContext.SaveChanges();        
        }
    }
}
