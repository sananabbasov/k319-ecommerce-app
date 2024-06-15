using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Repositories;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.DataAccess.Abstract;

public interface IProductDal : IRepositoryBase<Product>
{
    List<Product> GetRecentProducts();
    List<Product> SpecialOffers();

    Product GetById(int id);

    PaginationResponse<Product> ShopProducts(int currentPage, int minPrice, int maxPrice, int categoryId);
}
