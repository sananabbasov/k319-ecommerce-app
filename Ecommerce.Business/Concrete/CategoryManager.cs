using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Dtos.CategoryDtos;

namespace Ecommerce.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public List<CategoryHomeDto> GetHomeCategories()
    {
        var categories = _categoryDal.GetCategoriesWithProducts(12)
        .Select(x => new CategoryHomeDto
        {
            Id = x.Id,
            CategoryName = x.Name,
            ProductCount = x.Products.Count()
        }).ToList();

        return categories;
    }
}
