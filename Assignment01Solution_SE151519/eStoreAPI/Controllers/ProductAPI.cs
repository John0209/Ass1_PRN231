using AutoMapper;
using AutoMapper.Execution;
using BusinessObject.Service.IService;
using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
	[Route("api/product")]
	[ApiController]
	public class ProductAPI : ControllerBase
	{
		IProductService _product;
		IMapper _map;

		public ProductAPI(IProductService product, IMapper map)
		{
			_product = product;
			_map = map;
		}
		[HttpGet("Get-All")]
		public IActionResult GetProduct() 
		{
			var products= _product.GetProducts();
			if(products.Any())
			{
				var productMap = _map.Map<IEnumerable<ProductRespone>>(products);
				return Ok(productMap);
			}
			return BadRequest("Product is Empty!");
		}
        [HttpGet("Get-By-Id")]
        public IActionResult GetProductById(int id)
        {
            var products = _product.GetProductById(id);
			if (products != null)
            {
                var productMap = _map.Map<ProductRequest>(products);
                return Ok(productMap);
            }
            return BadRequest("Product is Empty!");
        }
        [HttpPut("Update")]
		public IActionResult UpdateProduct(ProductRequest product)
		{
			var products = _map.Map<Product>(product);
			var m_update= _product.UpdateProduct(products);
			if (m_update)
				return Ok();
			else
				return BadRequest();
		}
        [HttpGet("Search")]
        public IActionResult SearchProduct(string serachs)
        {
            var products = _product.SearchProduct(serachs);
            if (products.Any())
            {
                var ProductMap = _map.Map<IEnumerable<ProductRespone>>(products);
                return Ok(ProductMap);
            }
            return BadRequest("Product is Empty!");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            var products = _product.GetProductById(id);
            if (products != null)
			{
				_product.DeleteProduct(products);
                return Ok();
            }
            else
                return BadRequest();
        }
        [HttpPost("Create")]
        public IActionResult CreateProduct(ProductRequest productRequest)
        {
            var check = _product.GetProductById(productRequest.ProductId);
            if (check == null)
            {
				var product=_map.Map<Product>(productRequest);
                _product.AddProduct(product);
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}
