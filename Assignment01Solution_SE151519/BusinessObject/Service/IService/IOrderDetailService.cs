using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service.IService
{
	public interface IOrderDetailService
	{
		public IEnumerable<OrderDetail> GetOrderDetails();
		public bool UpdateOrderDetail(OrderDetail OrderDetail);
		public void DeleteOrderDetail(OrderDetail OrderDetail);
		public OrderDetail GetOrderDetailById(int orderId);

        public void AddOrderDetail(OrderDetail OrderDetail);
	}
}
