using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
	public interface IUnitRepository
	{
		public IMemberRepository MemberRepository { get; }
		public IProductRepository ProductRepository { get; }
		public IOrderDetailRepository OrderDetailRepository { get; }
		public IOrderRepository OrderRepository { get; }
	}
}
