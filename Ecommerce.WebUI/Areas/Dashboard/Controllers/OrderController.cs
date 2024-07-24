using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.WebUI.Areas.Dashboard.Controllers;


[Area("Dashboard")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IActionResult Index()
    {
        var result = _orderService.GetDashboardOrders();
        ViewBag.Status = Enum.GetValues(typeof(DeliveryStatus)).Cast<DeliveryStatus>(); ;
        return View(result.Data);
    }

    [HttpPost]
    public IActionResult Index(DeliveryStatus status, int id)
    {
        var changeStatus = _orderService.ChangeStatus(id, status);
        if (changeStatus.Success)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
