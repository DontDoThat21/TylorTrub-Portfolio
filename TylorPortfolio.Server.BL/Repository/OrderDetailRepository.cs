using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TylorTrubPortfolio.Server.BL.Data;
using TylorTrubPortfolio.Server.BL.Repository.IRepository;
using TylorTrubPortfolio.DTO.Models;

namespace TylorTrubPortfolio.Server.BL.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private PortfolioDBContext _db;
        public OrderDetailRepository(PortfolioDBContext db) : base(db)
        {
            _db = db;
        }



        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
