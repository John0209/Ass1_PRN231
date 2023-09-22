using AutoMapper;
using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;

namespace eStoreAPI.Mapper
{
	public class Mapper : Profile
	{
		public Mapper() 
		{
			CreateMap<Product, ProductRespone>().ForMember(dest => dest.CategoryName,
							otp => otp.MapFrom(src => src.Category != null ? src.Category.CategoryName : string.Empty)).
				ReverseMap();
			CreateMap<Order, OrderRespone>().ReverseMap();
			CreateMap<OrderDetail, OrderDetailRespone>().ReverseMap();
			CreateMap<Member, MemberRespone>().ReverseMap();

            CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailRespone>().ReverseMap();
            CreateMap<Member, MemberRequest>().ReverseMap();
			CreateMap<Product, ProductRequest>().ReverseMap();
        }
	}
}
