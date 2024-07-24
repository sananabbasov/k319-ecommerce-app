using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Entities.Dtos.OrderDtos;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Enums;

namespace Ecommerce.Business.Abstract;

public interface IOrderService
{
    void OrderProduct(List<ProductCartDto> productCart, string userId);
    IDataResult<List<OrderDashboardDto>> GetDashboardOrders();
    IResult ChangeStatus(int id, DeliveryStatus deliveryStatus);
}
