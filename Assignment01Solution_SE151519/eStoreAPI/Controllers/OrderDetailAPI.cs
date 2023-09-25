using AutoMapper;
using BusinessObject.Service.IService;
using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
	[Route("api/order-detail")]
	[ApiController]
	public class OrderDetailAPI : ControllerBase
	{
		IOrderDetailService _orderDetail;
		IMapper _map;
		public OrderDetailAPI(IOrderDetailService orderDetail, IMapper map)
		{
			_orderDetail = orderDetail;
			_map = map;
		}
        [HttpGet("Get-All")]
        public IActionResult GetOrder()
        {
            var orders = _orderDetail.GetOrderDetails();
            if (orders.Any())
            {
                var _orderMap = _map.Map<IEnumerable<OrderDetailRespone>>(orders);
                return Ok(_orderMap);
            }
            return BadRequest("Product is Empty!");
        }
        [HttpGet("Get-By-Id")]
        public IActionResult GetOrderById(int orderId)
        {
            var orders = _orderDetail.GetOrderDetailById(orderId);
            if (orders != null)
            {
                var _orderMap = _map.Map<OrderDetailRespone>(orders);
                return Ok(_orderMap);
            }
            return BadRequest("Product is Empty!");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteOrder(int orderId)
        {
            var orders = _orderDetail.GetOrderDetailById(orderId);
            if (orders != null)
            {
                _orderDetail.DeleteOrderDetail(orders);
                return Ok();
            }
            else
                return BadRequest();
        }
        [HttpPost("Create")]
        public IActionResult CreateOrder(OrderDetailRequest orderRequest)
        {
            var check = _orderDetail.GetOrderDetailById(orderRequest.OrderId);
            if (check == null)
            {
                var order = _map.Map<OrderDetail>(orderRequest);
                _orderDetail.AddOrderDetail(order);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
