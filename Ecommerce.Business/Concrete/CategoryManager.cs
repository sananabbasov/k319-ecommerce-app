using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
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

    public IResult DeleteCategory(int categoryId)
    {
        try
        {
            var category = _categoryDal.Get(x => x.Id == categoryId);
            if (category == null)
            {
                return new ErrorResult("Category not found");
            }
            category.IsDeleted = true;
            _categoryDal.Update(category);
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

    public IDataResult<CategoryUpdateDto> GetUpdateCategory(int categoryId)
    {
        try
        {
            var category = _categoryDal.Get(c => c.Id == categoryId);
            var map = _mapper.Map<CategoryUpdateDto>(category);

            return new SuccessDataResult<CategoryUpdateDto>(map);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<CategoryUpdateDto>(e.Message);
        }
    }

    public IResult UpdateCategory(int categoryId, CategoryUpdateDto categoryUpdate)
    {
        try
        {
            var getCategory = _categoryDal.Get(x => x.Id == categoryId);
            if (getCategory == null)
            {
                return new ErrorResult("Category not found");
            }
            getCategory.Name = categoryUpdate.Name;
            getCategory.IsActive = categoryUpdate.IsActive;
            _categoryDal.Update(getCategory);
            return new SuccessResult();
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }

    }
}
