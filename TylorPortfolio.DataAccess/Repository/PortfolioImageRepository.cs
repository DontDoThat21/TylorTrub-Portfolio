using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.DataAccess.Repository
{
    public class PortfolioImageRepository : Repository<PortfolioImage>, IPortfolioImageRepository
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
