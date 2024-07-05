using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.CategoryDtos;

namespace Ecommerce.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
    }

    public IResult CreateCategory(CategoryCreateDto categoryCreate)
    {
        try
        {
            var map = _mapper.Map<Category>(categoryCreate);
            _categoryDal.Add(map);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public List<CategoryProductDto> GetCategories()
    {
        var categories = _categoryDal.GetCategoriesWithProducts(12)
        .Select(x => new CategoryProductDto
        {
            Id = x.Id,
            CategoryName = x.Name
        }).ToList();

        return categories;
    }

    public IDataResult<List<CategoryDashboardDto>> GetDashboardCategories()
    {
        try
        {
            var categories = _categoryDal.GetAll();
            var result = _mapper.Map<List<CategoryDashboardDto>>(categories);
            return new SuccessDataResult<List<CategoryDashboardDto>>(result);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<List<CategoryDashboardDto>>(e.Message);
        }
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
