using AutoMapper;
using BusinessObject.Service.IService;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service
{
	public class ProductService : IProductService
	{
		IUnitRepository _unit;
		IMapper _mapper;

		public ProductService(IUnitRepository unit)
		{
			_unit = unit;
		}
		public void AddProduct(Product Product)
		{
            _unit.ProductRepository.Add(Product);
            _unit.ProductRepository.Save();
        }

		public void DeleteProduct(Product Product)
		{
			_unit.ProductRepository.Delete(Product);
            _unit.ProductRepository.Save();
        }

		public Product GetProductById(int id)
		{
			return _unit.ProductRepository.GetById(id);
		}
        public async Task<IQueryable<Product>> GetProductOData(ODataQueryOptions<Product> options, IMapper mapper)
        {
            return await _unit.ProductRepository.GetOData(options, mapper);
        }
        public IEnumerable<Product> GetProducts()
		{
			return _unit.ProductRepository.GetAll();
		}

        public IEnumerable<Product> SearchProduct(string searchs)
        {
            var products = GetProducts();
            searchs = searchs.ToLower();
			var productsSearch = products.Where(x => x.ProductName.ToLower().Contains(searchs));
            return productsSearch;
        }
        
        public bool UpdateProduct(Product Product)
		{
			var productUpdate = GetProductById(Product.ProductId);
			if(productUpdate != null)
			{
				productUpdate.ProductName = Product.ProductName;
				productUpdate.Weight = Product.Weight;
				productUpdate.CategoryId= Product.CategoryId;
				productUpdate.UnitPrice = Product.UnitPrice;
				productUpdate.UnitsInStock = Product.UnitsInStock;
				_unit.ProductRepository.Update(productUpdate);
				_unit.ProductRepository.Save();
				return true;
			}
			return false;
		}
	}
}
