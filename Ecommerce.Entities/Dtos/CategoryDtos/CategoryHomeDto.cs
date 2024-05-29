using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.CategoryDtos;

public class CategoryHomeDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public int ProductCount { get; set; }
}
