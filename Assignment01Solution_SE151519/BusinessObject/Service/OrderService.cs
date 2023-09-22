using BusinessObject.Service.IService;
using DataAccess.IRepositories;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service
{
	public class OrderService:IOrderService
	{
		IUnitRepository _unit;

		public OrderService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public bool AddOrder(Order Order)
		{
			throw new NotImplementedException();
		}

		public bool DeleteOrder(Order Order)
		{
			throw new NotImplementedException();
		}

		public Order GetOrderById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Order> GetOrders()
		{
			throw new NotImplementedException();
		}

		public bool UpdateOrder(Order Order)
		{
			throw new NotImplementedException();
		}
	}
}
