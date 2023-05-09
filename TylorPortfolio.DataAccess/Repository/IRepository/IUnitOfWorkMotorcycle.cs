using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.DataAccess.Repository.IRepository
{
    public interface IUnitOfWorkMotorcycle
    {
        IMotorcycleRepository Motorcycle { get; }

        void Save();

    }
}
