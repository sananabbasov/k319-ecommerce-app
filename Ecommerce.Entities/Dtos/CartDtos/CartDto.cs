using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.CartDtos;

public class CartDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
