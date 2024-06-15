using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Payloads;



namespace Ecommerce.Business.Concrete;

public class ProductManager : IProductService
{

    private readonly IProductDal _productDal;
    private readonly IMapper _mapper;

    public ProductManager(IProductDal productDal, IMapper mapper)
    {
        _productDal = productDal;
        _mapper = mapper;
    }

    public List<RecentProductDto> GetHomeRecentProduct()
    {
        var products = _productDal.GetRecentProducts();
        var result = _mapper.Map<List<RecentProductDto>>(products);
        return result;
    }

    public ProductDetailDto GetProductDetail(int id)
    {
        var product = _productDal.GetById(id);
        var result = _mapper.Map<ProductDetailDto>(product);
        return result;
    }

    public List<ProductCartDto> GetProductsById(List<int> ids)
    {
        var products = _productDal.GetAll(x => ids.Contains(x.Id));
        var result = _mapper.Map<List<ProductCartDto>>(products);
        return result;
    }

    public List<SpecialOfferDto> GetSpecialOffers()
    {
        var products = _productDal.SpecialOffers();
        var result = _mapper.Map<List<SpecialOfferDto>>(products);
        return result;
    }

    public PaginationResponse<ProductShopDto> ShopProducts(int currentPage, int minPrice, int maxPrice, int categoryId)
    {
        var products = _productDal.ShopProducts(currentPage, minPrice, maxPrice, categoryId);
        var mapper = _mapper.Map<List<ProductShopDto>>(products.Data);
        PaginationResponse<ProductShopDto> pagination = new()
        {
            PageSize = products.PageSize / 9,
            CurrentPage = currentPage,
            Data = mapper
        };
        return pagination;
    }
}
