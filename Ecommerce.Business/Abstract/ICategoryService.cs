using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Entities.Dtos.CategoryDtos;

namespace Ecommerce.Business.Abstract;

public interface ICategoryService
{
    List<CategoryHomeDto> GetHomeCategories();
    List<CategoryProductDto> GetCategories();
    IResult CreateCategory(CategoryCreateDto categoryCreate);

    IDataResult<List<CategoryDashboardDto>> GetDashboardCategories();

}
