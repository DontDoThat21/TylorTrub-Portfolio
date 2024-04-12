using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DTO.Models;

namespace TylorTrubPortfolio.Server.BL.Repository.IRepository
{
    public interface IGamesRepository : IRepository<Game>
    {
        void Update(Game obj);
    }
}
