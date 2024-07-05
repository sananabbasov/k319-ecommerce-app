using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
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

    public bool CreateProduct(ProductCreateDto productCreateDto)
    {
        try
        {
            var product = _mapper.Map<Product>(productCreateDto);
            _productDal.Add(product);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public List<ProductDashboardListDto> GetDashboardProducts()
    {
        var products = _productDal.GetAll(x=>x.IsDeleted != true);
        return _mapper.Map<List<ProductDashboardListDto>>(products);
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

    public ProductUpdateDto GetUpdatedProduct(int id)
    {
        var product = _productDal.GetById(id);
        var result = _mapper.Map<ProductUpdateDto>(product);
        return result;
    }

    public bool RemoveProduct(int id)
    {
        try
        {
            var product = _productDal.GetById(id);
            if (product == null)
                return false;

            product.IsDeleted = true;
            _productDal.Update(product);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
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

    public bool UpdateProduct(int id, ProductUpdateDto productCreateDto)
    {
        try
        {
            var product = _productDal.GetById(id);
            if (product == null)
            {
                return false;
            }
            product.Name = productCreateDto.Name;
            product.Price = productCreateDto.Price;
            product.Description = productCreateDto.Description;
            product.CategoryId = productCreateDto.CategoryId;
            product.Information = productCreateDto.Information;
            product.IsFeatured = productCreateDto.IsFeatured;
            product.Stock = productCreateDto.Stock;
            product.DiscountPrice = productCreateDto.DiscountPrice;
            _productDal.Update(product);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}
