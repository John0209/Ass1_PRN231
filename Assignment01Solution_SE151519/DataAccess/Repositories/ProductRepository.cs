using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(FStoreDBContext context) : base(context)
		{
		}
        public override IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().
                Include(x=> x.Category).ToList();
        }
        public override Product GetById(int id)
        {
            return _context.Set<Product>()
                  .Include(x => x.Category)
                  .FirstOrDefault(x => x.ProductId == id);
        }
    }
}
