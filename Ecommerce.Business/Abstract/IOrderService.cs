using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.ProductDtos;

namespace Ecommerce.Business.Abstract;

public interface IOrderService
{
    void OrderProduct(List<ProductCartDto> productCart, string userId);
}
