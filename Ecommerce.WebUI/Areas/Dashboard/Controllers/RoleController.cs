using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.RoleDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.WebUI.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class RoleController : Controller
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var roles = await _roleService.GetRoles();
        return View(roles.Data);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoleCreateDto roleCreateDto)
    {
        var result = await _roleService.CreateRole(roleCreateDto);
        if (result.Success){
            return RedirectToAction("Index");
        }
        return View(roleCreateDto);
    }
}
