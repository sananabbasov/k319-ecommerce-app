using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.CartDtos;
using Ecommerce.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Controllers;


public class OrderController : Controller
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly IDistributedCache _cache;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;




    public OrderController(IHttpContextAccessor httpContext, IDistributedCache cache, IProductService productService, IOrderService orderService)
    {
        _httpContext = httpContext;
        _cache = cache;
        _productService = productService;
        _orderService = orderService;
    }

    public async Task<IActionResult> Index()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Auth");
        }
        var findCookie = Request.Cookies["basket"];
        string find = await _cache.GetStringAsync($"basket:{findCookie}");
        if (find == null)
        {
            return View(new List<ProductCartDto>());
        }
        var items = JsonConvert.DeserializeObject<List<CartDto>>(find);
        var cartProduct = _productService.GetProductsById(items.Select(x => x.ProductId).ToList());
        foreach (var cart in cartProduct)
        {
            cart.Quantity = items.FirstOrDefault(z => z.ProductId == cart.Id).Quantity;
        }

        var userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        _orderService.OrderProduct(cartProduct,userId);

        return RedirectToAction("Index","Home");
    }
}
