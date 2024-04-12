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
