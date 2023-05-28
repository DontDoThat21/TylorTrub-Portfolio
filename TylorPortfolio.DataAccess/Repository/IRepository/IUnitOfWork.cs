using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IMotorcycleRepository Motorcycle { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IMotorcycleVideosRepository MotorcycleVideos { get; }
        IPortfolioImagesRepository PortfolioImages { get; }
        ICompanyRepository Company { get; }
        IGamesRepository Games { get; }
        IProjectRepository Projects { get; }

        void Save();

    }
}
