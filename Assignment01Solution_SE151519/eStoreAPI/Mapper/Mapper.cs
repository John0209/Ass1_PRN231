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
			CreateMap<Order, OrderRespone>().ForMember(dest => dest.Email,
                            otp => otp.MapFrom(src => src.Member != null ? src.Member.Email : string.Empty))
				.ReverseMap();
			CreateMap<OrderDetail, OrderDetailRespone>().ForMember(dest => dest.ProductName,
                            otp => otp.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty))
                .ReverseMap();
            CreateMap<Member, MemberRespone>().ReverseMap();
			CreateMap<Member, Member>();

            CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailRequest>().ReverseMap();
            CreateMap<Member, MemberRequest>().ReverseMap();
			CreateMap<Product, ProductRequest>().ReverseMap();
            CreateMap<Product, Product>().ReverseMap();
        }
	}
}
