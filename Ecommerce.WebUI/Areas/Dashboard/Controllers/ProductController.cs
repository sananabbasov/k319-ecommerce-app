using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.WebUI.Areas.Dashboard.Controllers;


[Area("Dashboard")]
public class ProductController : Controller
{

    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetDashboardProducts();
        return View(products);
    }


    [HttpGet]
    public IActionResult Update(int id)
    {
        var products = _productService.GetUpdatedProduct(id);
        var categories = _categoryService.GetCategories();
        ViewBag.Categories = categories;
        return View(products);
    }


    [HttpPost]
    public IActionResult Update(int id, ProductUpdateDto productUpdateDto)
    {
        var products = _productService.UpdateProduct(id, productUpdateDto);

        if (products)
        {
            return RedirectToAction("Index");
        }
        var categories = _categoryService.GetCategories();
        ViewBag.Categories = categories;
        return View(products);
    }


    [HttpGet]
    public IActionResult Create()
    {
        var categories = _categoryService.GetCategories();
        ViewBag.Categories = categories;
        return View();
    }

    [HttpPost]
    public IActionResult Create(ProductCreateDto productCreateDto)
    {
        var res = _productService.CreateProduct(productCreateDto);

        if (res)
        {
            return RedirectToAction("Index");
        }
        var categories = _categoryService.GetCategories();
        ViewBag.Categories = categories;
        return View(productCreateDto);
    }

    [HttpGet]
    public IActionResult Remove(int id)
    {
        var res = _productService.RemoveProduct(id);
        if (res){
            return RedirectToAction("Index");
        }
        return View();
    }

}
