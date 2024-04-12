using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.DataAccess.Repository.IRepository
{
    public interface IPortfolioImagesRepository : IRepository<PortfolioImage>
    {
        void Update(PortfolioImage obj);
    }
}
