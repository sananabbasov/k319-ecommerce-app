using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.Business.Abstract;

public interface IProductService
{
    List<RecentProductDto> GetHomeRecentProduct();
    List<SpecialOfferDto> GetSpecialOffers();
    ProductDetailDto GetProductDetail(int id);

    List<ProductCartDto> GetProductsById(List<int> ids);

    PaginationResponse<ProductShopDto> ShopProducts(int currentPage, int minPrice, int maxPrice, int categoryId);
}
