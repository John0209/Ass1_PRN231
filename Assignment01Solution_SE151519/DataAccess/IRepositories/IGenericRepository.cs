using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
	public interface IGenericRepository<T> where T : class
	{
    IEnumerable<T> GetAll();
	T GetById(int id);
    T GetOrderDetailById(int orderId, int productId);
    void Delete(T entity);
	void Update(T entity);
	void Add(T entity);
	void Save();
	}
}
