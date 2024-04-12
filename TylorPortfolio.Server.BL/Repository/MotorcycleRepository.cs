using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.Server.BL.Data;
using TylorTrubPortfolio.Server.BL.Repository.IRepository;
using TylorTrubPortfolio.DTO.Models;

namespace TylorTrubPortfolio.Server.BL.Repository
{
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
    {
        private PortfolioDBContext _db;

        public MotorcycleRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Motorcycle obj)
        {
            _db.Motorcycles.Update(obj);
        }
    }
}
