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
	public class OrderDetailService:IOrderDetailService
	{
		IUnitRepository _unit;

		public OrderDetailService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public bool AddOrderDetail(OrderDetail OrderDetail)
		{
			throw new NotImplementedException();
		}

		public bool DeleteOrderDetail(OrderDetail OrderDetail)
		{
			throw new NotImplementedException();
		}

		public OrderDetail GetOrderDetailById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<OrderDetail> GetOrderDetails()
		{
			throw new NotImplementedException();
		}

		public bool UpdateOrderDetail(OrderDetail OrderDetail)
		{
			throw new NotImplementedException();
		}
	}
}
