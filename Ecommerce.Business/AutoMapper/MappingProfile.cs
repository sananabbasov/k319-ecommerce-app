using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.CategoryDtos;
using Ecommerce.Entities.Dtos.ProductDtos;

namespace Ecommerce.Business.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, RecentProductDto>()
            .ForMember(x => x.PhotoUrl, o => o.MapFrom(s => s.Photos.FirstOrDefault().Url))
            .ForMember(x => x.ReviewCount, o => o.MapFrom(s => s.Reviews.Count()));

        CreateMap<Product, SpecialOfferDto>()
            .ForMember(x => x.PhotoUrl, o => o.MapFrom(s => s.Photos.FirstOrDefault().Url))
            .ForMember(x => x.Discount, o => o.MapFrom(s => s.DiscountPrice / s.Price * 100));


        CreateMap<Product, ProductDetailDto>()
            .ForMember(x => x.Photos, o => o.MapFrom(s => s.Photos.Select(x => x.Url).ToList()))
            .ForMember(x => x.TotalPoint, o => o.MapFrom(s => s.Reviews.Average(x => x.Point)));


        CreateMap<Product, ProductCartDto>()
             .ForMember(x => x.PhotoUrl, o => o.MapFrom(s => s.Photos.FirstOrDefault().Url));


        CreateMap<Product, ProductShopDto>()
            .ForMember(x => x.PhotoUrl, o => o.MapFrom(s => s.Photos.FirstOrDefault().Url));

        CreateMap<Product, ProductDashboardListDto>();

        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();


        CreateMap<CategoryCreateDto, Category>();
        CreateMap<Category, CategoryDashboardDto>();
        
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }
}
