using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.BastekDtos;

public class BasketDto
{
    public string Id { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }
}
