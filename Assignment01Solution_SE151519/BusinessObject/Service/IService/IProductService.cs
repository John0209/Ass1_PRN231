using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service.IService
{
	public interface IProductService
	{
		public IEnumerable<Product> GetProducts();
		public bool UpdateProduct(Product Product);
		public void DeleteProduct(Product Product);
		public Product GetProductById(int id);
		public void AddProduct(Product Product);
        public IEnumerable<Product> SearchProduct(string searchs);
		public Task<IQueryable<Product>> GetProductOData(ODataQueryOptions<Product> options, IMapper mapper);
    }
}
