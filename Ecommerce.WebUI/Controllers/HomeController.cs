using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebUI.Models;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Business.Abstract;
using Ecommerce.WebUI.ViewModels;

namespace Ecommerce.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public HomeController(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }

    public IActionResult Index()
    {
        var result = _categoryService.GetHomeCategories();
        var recentProducts = _productService.GetHomeRecentProduct();
        var offers = _productService.GetSpecialOffers();
        HomeVm homeVm = new()
        {
            CategoryHome = result,
            RecentProducts =recentProducts,
            SpecialOffers = offers
        };
        return View(homeVm);
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
