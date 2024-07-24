using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Enums;

namespace Ecommerce.Entities.Dtos.OrderDtos;

public class OrderDashboardDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string DeliveryAddress { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public bool PaymentStatus { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public string UserFullName { get; set; }
}
