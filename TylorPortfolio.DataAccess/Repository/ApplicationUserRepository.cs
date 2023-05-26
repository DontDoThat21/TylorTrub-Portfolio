using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;
using TylorTrubPortfolio.Models;
using TylorTrubPortfolio.Models.Models;

namespace TylorTrubPortfolio.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private PortfolioDBContext _db;

        public ApplicationUserRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }

    }
}
