using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service.IService
{
	public interface IOrderService
	{
		public IEnumerable<Order> GetOrders();
		public bool UpdateOrder(Order Order);
		public bool DeleteOrder(Order Order);
		public Order GetOrderById(int id);
		public bool AddOrder(Order Order);
	}
}
