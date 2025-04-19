using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Server.BL.Data;
using Portfolio.Server.BL.Repository.IRepository;
using Portfolio.DTO.Models;

namespace Portfolio.Server.BL.Repository
{
    public class GameRepository : Repository<Game>, IGamesRepository
    {
        private PortfolioDBContext _db;

        public GameRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Game obj)
        {
            _db.Games.Update(obj);
        }
    }
}
