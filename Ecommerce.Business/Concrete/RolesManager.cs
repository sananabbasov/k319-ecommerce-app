using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business.Abstract;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.RoleDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Business.Concrete;

public class RolesManager : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;

    public RolesManager(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<IResult> AddRole(string roleName, string userId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles =  await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user,userRoles);
            var addRole = await _userManager.AddToRoleAsync(user, roleName);
            if (addRole.Succeeded)
            {
                return new SuccessResult("Role added");
            }
            return new ErrorResult();
        }
        catch (Exception e) 
        {
            return new ErrorResult(e.Message);
        }
    }

    public async Task<IResult> CreateRole(RoleCreateDto role)
    {
        try
        {
            var findRole = await _roleManager.FindByNameAsync(role.RoleName);
            if (findRole != null)
            {
                return new ErrorResult("Role already exists");
            }
            _roleManager.CreateAsync(new IdentityRole(role.RoleName)).GetAwaiter().GetResult();
            return new SuccessResult("Rol yaradildi");
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public async Task<IDataResult<List<IdentityRole>>> GetRoles()
    {
        try
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return new SuccessDataResult<List<IdentityRole>>(roles);
        }
        catch (Exception e)
        {
            return new ErrorDataResult<List<IdentityRole>>(e.Message);
        }
    }

    public string test()
    {

        return "DSal";
    }
}
