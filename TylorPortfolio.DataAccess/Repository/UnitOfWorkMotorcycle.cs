using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;

namespace TylorTrubPortfolio.DataAccess.Repository
{
    public class UnitOfWorkMotorcycle : IUnitOfWorkMotorcycle
    {
        private MotorcycleDBContext _motorDb;
        public IMotorcycleRepository Motorcycle { get; private set; }
        public UnitOfWorkMotorcycle(MotorcycleDBContext motorDb)
        {
            _motorDb = motorDb;

            Motorcycle = new MotorcycleRepository(_motorDb);
        }

        public void Save()
        {
            _motorDb.SaveChanges();        
        }
    }
}
