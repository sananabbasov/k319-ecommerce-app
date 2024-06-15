using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.ProductDtos;

public class SpecialOfferDto
{
    public int Id { get; set; }
    public string PhotoUrl { get; set; }
    public int Discount { get; set; }
}
