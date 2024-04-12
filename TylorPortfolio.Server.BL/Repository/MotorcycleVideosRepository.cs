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
    public class MotorcycleVideosRepository : Repository<MotorcycleVideo>, IMotorcycleVideosRepository
    {
        private PortfolioDBContext _db;

        public MotorcycleVideosRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MotorcycleVideo obj)
        {
            _db.MotorcycleVideos.Update(obj);
        }
    }
}
