using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Enums;

namespace Ecommerce.Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    public void OrderProduct(List<ProductCartDto> productCart, string userId)
    {
        decimal totalPrice = productCart.Sum(x => x.TotalPrice);

        List<OrderItem> orderItems = new();
        Order order = new()
        {
            TotalPrice = totalPrice,
            DeliveryAddress = "sdf",
            OrderDate = DateTime.Now,
            PaymentStatus = true,
            DeliveryStatus = DeliveryStatus.PENDING,
            UserId = userId,
            OrderItems = orderItems,
            PhoneNumber = "test"
        };
        foreach (var item in productCart)
        {
            OrderItem orderItem = new()
            {
                Price = item.Price,
                DiscountPrice = item.Price,
                ProductId = item.Id,
                Order = order
            };
            orderItems.Add(orderItem);
        }

        _orderDal.Add(order);
    }
}
