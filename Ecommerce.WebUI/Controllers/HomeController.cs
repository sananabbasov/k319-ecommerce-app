using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebUI.Models;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Business.Abstract;

namespace Ecommerce.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;

    public HomeController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var result = _categoryService.GetHomeCategories();
        return View(result);
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
