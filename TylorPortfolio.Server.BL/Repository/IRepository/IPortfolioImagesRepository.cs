using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DTO.Models;

namespace TylorTrubPortfolio.Server.BL.Repository.IRepository
{
    public interface IPortfolioImagesRepository : IRepository<PortfolioImage>
    {
        void Update(PortfolioImage obj);
    }
}
