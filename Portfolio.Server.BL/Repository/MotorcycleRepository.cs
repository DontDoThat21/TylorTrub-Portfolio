using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Server.BL.Data;
using Portfolio.Server.BL.Repository.IRepository;
using Portfolio.DTO.Models;

namespace Portfolio.Server.BL.Repository
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
