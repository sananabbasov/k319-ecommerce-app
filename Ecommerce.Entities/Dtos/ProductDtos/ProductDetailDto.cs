using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Concrete;

namespace Ecommerce.Entities.Dtos.ProductDtos;

public class ProductDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Information { get; set; }
    public List<string> Photos { get; set; }
    public double TotalPoint { get; set; }
    public List<Review> Reviews { get; set; }
}
