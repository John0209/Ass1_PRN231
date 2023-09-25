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

		public void AddOrderDetail(OrderDetail OrderDetail)
		{
            _unit.OrderDetailRepository.Add(OrderDetail);
            _unit.OrderDetailRepository.Save();
        }

		public void DeleteOrderDetail(OrderDetail OrderDetail)
		{
            _unit.OrderDetailRepository.Delete(OrderDetail);
            _unit.OrderDetailRepository.Save();
        }

		public OrderDetail GetOrderDetailById(int orderId)
		{
            return _unit.OrderDetailRepository.GetById(orderId);
        }

		public IEnumerable<OrderDetail> GetOrderDetails()
		{
            return _unit.OrderDetailRepository.GetAll();
        }

		public bool UpdateOrderDetail(OrderDetail OrderDetail)
		{
			throw new NotImplementedException();
		}
	}
}
