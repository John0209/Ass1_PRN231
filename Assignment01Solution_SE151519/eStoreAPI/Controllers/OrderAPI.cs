using AutoMapper;
using BusinessObject.Service.IService;
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
	}
}
