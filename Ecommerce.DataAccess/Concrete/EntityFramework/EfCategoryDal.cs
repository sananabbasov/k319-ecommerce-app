using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Repositories.EntityFramework;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class EfCategoryDal : EfRepositoryBase<Category, AppDbContext>, ICategoryDal
{
    public List<Category> GetCategoriesWithProducts(int count)
    {
        using var context = new AppDbContext();
        var categories = context.Categories.Include(x=>x.Products).Take(count).ToList();
        return categories;
    }
}
