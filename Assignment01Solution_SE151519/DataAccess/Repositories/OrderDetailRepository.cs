using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
	{
		public OrderDetailRepository(FStoreDBContext context) : base(context)
		{
		}
        public override IEnumerable<OrderDetail> GetAll()
        {
            return _context.Set<OrderDetail>().
                Include(x => x.Product).ToList();
        }
        public override OrderDetail GetById(int id)
        {
            return _context.Set<OrderDetail>().Where(x => x.OrderId == id).
                Include(x=> x.Product).FirstOrDefault();
        }
    }
}
