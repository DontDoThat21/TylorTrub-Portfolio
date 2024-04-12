using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.DataAccess.Data;
using TylorTrubPortfolio.DataAccess.Repository.IRepository;
using TylorTrubPortfolio.Models;

namespace TylorTrubPortfolio.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private PortfolioDBContext _db;

        public ProjectRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Project obj)
        {
            _db.Projects.Update(obj);
        }
    }
}
