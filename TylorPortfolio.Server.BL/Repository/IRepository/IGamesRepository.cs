using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.DataAccess.Repository.IRepository
{
    public interface IGamesRepository : IRepository<Game>
    {
        void Update(Game obj);
    }
}
