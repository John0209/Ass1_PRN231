using AutoMapper;
using BusinessObject.Service.IService;
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
	}
}
