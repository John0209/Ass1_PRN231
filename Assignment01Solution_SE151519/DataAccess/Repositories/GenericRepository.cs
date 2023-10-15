using AutoMapper;
using AutoMapper.AspNet.OData;
using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		public FStoreDBContext _context;
		public GenericRepository(FStoreDBContext context)
		{
			_context = context;
		}
		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public virtual IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public virtual T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

        public T GetOrderDetailById(int orderId, int productId)
        {
            return _context.Set<T>().Find(orderId,productId);
        }

        public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}
        public Task<IQueryable<T>> GetOData(ODataQueryOptions<T> options, IMapper mapper)
		{
			return _context.Set<T>().GetQueryAsync(mapper, options, null);
        }

    }
}
