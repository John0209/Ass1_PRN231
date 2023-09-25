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
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(FStoreDBContext context) : base(context)
		{
		}
        public override IEnumerable<Order> GetAll()
        {
            return _context.Set<Order>().
                Include(x => x.Member).ToList();
        }
    }
}
