using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.ProductDtos;

public class ProductCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Information { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public bool IsFeatured { get; set; }
}
