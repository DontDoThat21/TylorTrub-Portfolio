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
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
    {
        private MotorcycleDBContext _db;

        public MotorcycleRepository(MotorcycleDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Motorcycle obj)
        {
            _db.Motorcycles.Update(obj);
        }
    }
}
