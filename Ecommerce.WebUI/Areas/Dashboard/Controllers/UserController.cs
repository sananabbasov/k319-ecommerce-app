using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.WebUI.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class UserController(IUserService userService, IRoleService roleService) : Controller
{
    private readonly IUserService _userService = userService;
    private readonly IRoleService _roleService = roleService;

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetDashboardUsers();
        var a = await _roleService.GetRoles();
        ViewBag.Roles = a.Data;
        return View(users.Data);
    }


    [HttpPost]
    public async Task<IActionResult> Index(string userId, string role)
    {
        var addRole  = await _roleService.AddRole(role, userId);
        return RedirectToAction("Index");
    }
}
