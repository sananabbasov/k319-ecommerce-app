using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.OrderDtos;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Enums;

namespace Ecommerce.Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;
    private readonly IMapper _mapper;

    public OrderManager(IOrderDal orderDal, IMapper mapper)
    {
        _orderDal = orderDal;
        _mapper = mapper;
    }

    public IResult ChangeStatus(int id, DeliveryStatus deliveryStatus)
    {
        try
        {
            var order = _orderDal.Get(x => x.Id == id);
            if (order == null)
                return new ErrorResult("Order not found");
            order.DeliveryStatus = deliveryStatus;
            _orderDal.Update(order);
            return new SuccessResult("Order status changed");
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public IDataResult<List<OrderDashboardDto>> GetDashboardOrders()
    {
        try
        {
            var orders = _orderDal.GetDashboardOrders();
            var mapper = _mapper.Map<List<OrderDashboardDto>>(orders);
            return new SuccessDataResult<List<OrderDashboardDto>>(mapper);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<List<OrderDashboardDto>>(e.Message);
        }
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
