using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Repositories.EntityFramework;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Payloads;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
{
    public Product GetById(int id)
    {
        using var context = new AppDbContext();
        var product = context.Products.Include(x => x.Photos).Include(x => x.Reviews).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);
        return product;
    }

    public List<Product> GetRecentProducts()
    {
        using var context = new AppDbContext();
        var products = context.Products.Include(x => x.Photos).Include(x => x.Reviews).ThenInclude(x => x.User).OrderByDescending(x => x.Id).Take(8).ToList();
        return products;
    }

    public PaginationResponse<Product> ShopProducts(int currentPage, int minPrice, int maxPrice, int categoryId)
    {
        using var context = new AppDbContext();
        int skip = (currentPage - 1) * 9; // 2 - 1  = 1  * 9 = 9
        var products = new List<Product>();
        int productCount = 0;
        if (categoryId != 0)
        {
            products = context.Products.Include(x => x.Photos).Where(x => x.CategoryId == categoryId).OrderByDescending(x => x.Id).Skip(skip).Take(9).ToList();
            productCount = context.Products.Where(x => x.CategoryId == categoryId).Count();
        }
        else
        {
            products = context.Products.Include(x => x.Photos).OrderByDescending(x => x.Id).Skip(skip).Take(9).ToList();
            productCount = context.Products.Count();
        }
        PaginationResponse<Product> pagination = new()
        {
            PageSize = productCount,
            CurrentPage = currentPage,
            Data = products
        };
        return pagination;
    }

    public List<Product> SpecialOffers()
    {
        using var context = new AppDbContext();
        var products = context.Products.Include(x => x.Photos).OrderBy(x => x.Price - x.DiscountPrice).Take(2).ToList();
        return products;
    }
}
