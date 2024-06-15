using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.ProductDtos;

public class ProductShopDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhotoUrl { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public double ReviewPoint { get; set; }
    public double ReviewCount { get; set; }
}
