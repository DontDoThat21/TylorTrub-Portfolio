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
    public class PortfolioImageRepository : Repository<PortfolioImage>, IPortfolioImagesRepository
    {
        private PortfolioDBContext _db;

        public PortfolioImageRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PortfolioImage obj)
        {
            _db.PortfolioImages.Update(obj);
        }
    }
}
