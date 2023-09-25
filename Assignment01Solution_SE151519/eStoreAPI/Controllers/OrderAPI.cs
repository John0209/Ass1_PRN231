using AutoMapper;
using BusinessObject.Service.IService;
using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
	[Route("api/order")]
	[ApiController]
	public class OrderAPI : ControllerBase
	{
		IOrderService _order;
		IMapper _map;

		public OrderAPI(IOrderService order, IMapper map)
		{
			_order = order;
			_map = map;
		}
        [HttpGet("Get-All")]
        public IActionResult GetOrder()
        {
            var orders = _order.GetOrders();
            if (orders.Any())
            {
                var _orderMap = _map.Map<IEnumerable<OrderRespone>>(orders);
                return Ok(_orderMap);
            }
            return BadRequest("Product is Empty!");
        }
        [HttpGet("Get-By-Id")]
        public IActionResult GetOrderById(int id)
        {
            var orders = _order.GetOrderById(id);
            if (orders != null)
            {
                var _orderMap = _map.Map<OrderRequest>(orders);
                return Ok(_orderMap);
            }
            return BadRequest("Product is Empty!");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteOrder(int id)
        {
            var orders = _order.GetOrderById(id);
            if (orders != null)
            {
                _order.DeleteOrder(orders);
                return Ok();
            }
            else
                return BadRequest();
        }
        [HttpPost("Create")]
        public IActionResult CreateOrder(OrderRequest orderRequest)
        {
            var check = _order.GetOrderById(orderRequest.OrderId);
            if (check == null)
            {
                var order = _map.Map<Order>(orderRequest);
                _order.AddOrder(order);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
