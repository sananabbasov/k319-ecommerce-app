using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.WebUI.Areas.Dashboard.Controllers;


[Area("Dashboard")]
public class CategoryController : Controller
{

    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var result = _categoryService.GetDashboardCategories();
        return View(result.Data);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CategoryCreateDto categoryCreateDto)
    {
        var result = _categoryService.CreateCategory(categoryCreateDto);
        if (result.Success)
        {
            return RedirectToAction("Index");
        }
        return View(result);
    }



    [HttpGet]
    public IActionResult Update(int id)
    {
        var category = _categoryService.GetUpdateCategory(id);
        return View(category.Data);
    }

    [HttpPost]
    public IActionResult Update(int id, CategoryUpdateDto categoryUpdate)
    {
        var result = _categoryService.UpdateCategory(id, categoryUpdate);
        if (result.Success)
        {
            return RedirectToAction("Index");
        }
        return View(result);
    }

    [HttpGet]
    public IActionResult Remove(int id)
    {
        var result = _categoryService.DeleteCategory(id);
        if (result.Success)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

}
