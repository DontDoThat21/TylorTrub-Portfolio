using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.Server.BL.Data;
using TylorTrubPortfolio.Server.BL.Repository.IRepository;
using TylorTrubPortfolio.DTO;

namespace TylorTrubPortfolio.Server.BL.Repository
{
    public class PortfolioImageRepository : Repository<PortfolioImage>, IPortfolioImagesRepository
    {
        private PortfolioDBContext _db;

        public PortfolioImageRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PortfolioImage obj)
        {
            _db.PortfolioImageVideos.Update(obj);
        }
    }
}
