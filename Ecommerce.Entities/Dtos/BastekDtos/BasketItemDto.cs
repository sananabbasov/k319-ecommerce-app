using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.BastekDtos;

public class BasketItemDto
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
}
