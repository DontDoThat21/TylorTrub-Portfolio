using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.Server.BL.Repository.IRepository
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
        IProductImageRepository ProductImage { get; }
        ICompanyRepository Company { get; }
        IGamesRepository Games { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IProjectRepository Projects { get; }

        void Save();

    }
}
