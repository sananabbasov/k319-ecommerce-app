using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Enums;

namespace Ecommerce.Entities.Concrete;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }
    public string DeliveryAddress { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public bool PaymentStatus { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
