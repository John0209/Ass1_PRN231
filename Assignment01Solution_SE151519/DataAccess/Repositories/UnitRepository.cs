using DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public class UnitRepository : IUnitRepository
	{
		public IMemberRepository MemberRepository { get; }

		public IProductRepository ProductRepository { get; }

		public IOrderDetailRepository OrderDetailRepository { get; }

		public IOrderRepository OrderRepository { get; }

		public UnitRepository(IMemberRepository memberRepository, 
			IProductRepository productRepository, IOrderDetailRepository orderDetailRepository, 
			IOrderRepository orderRepository)
		{
			MemberRepository = memberRepository;
			ProductRepository = productRepository;
			OrderDetailRepository = orderDetailRepository;
			OrderRepository = orderRepository;
		}

	}
}
