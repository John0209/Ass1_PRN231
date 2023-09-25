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

		public void AddOrder(Order Order)
		{
            _unit.OrderRepository.Add(Order);
            _unit.OrderRepository.Save();
        }

		public void DeleteOrder(Order Order)
		{
            _unit.OrderRepository.Delete(Order);
            _unit.OrderRepository.Save();
        }

		public Order GetOrderById(int id)
		{
            return _unit.OrderRepository.GetById(id);
        }

		public IEnumerable<Order> GetOrders()
		{
            return _unit.OrderRepository.GetAll();
        }

		public bool UpdateOrder(Order Order)
		{
			throw new NotImplementedException();
		}
	}
}
