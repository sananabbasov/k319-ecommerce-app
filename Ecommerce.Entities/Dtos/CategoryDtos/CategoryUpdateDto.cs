using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.CategoryDtos;

public class CategoryUpdateDto
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
