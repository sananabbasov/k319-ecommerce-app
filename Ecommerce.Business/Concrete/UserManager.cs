using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Core.Utilities.Results.Concrete.Error;
using Ecommerce.Core.Utilities.Results.Concrete.Success;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Dtos.UserDtos;

namespace Ecommerce.Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;
    private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;


    public UserManager(IUserDal userDal, IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<User> userManager)
    {
        _userDal = userDal;
        _mapper = mapper;
        _userManager = userManager;
    }


    public async Task<IResult> AddRole(UserAddRoleDto userAddRoleDto)
    {
        try
        {
            var findUser = await _userManager.FindByIdAsync(userAddRoleDto.UserId);
            var userRoles = await _userManager.GetRolesAsync(findUser);
            await _userManager.RemoveFromRolesAsync(findUser, userRoles);
            var addRole = await _userManager.AddToRoleAsync(findUser, userAddRoleDto.RoleName);
            if (addRole.Succeeded)
            {
                return new SuccessResult();
            }
            return new ErrorResult(addRole.Errors.FirstOrDefault().Description);
        }
        catch (Exception e)
        {
            return new ErrorResult(e.Message);
        }
    }

    public async Task<IDataResult<List<UserDashboardDto>>> GetDashboardUsers()
    {
        try
        {
            var users = _userDal.GetAll();
            var map = _mapper.Map<List<UserDashboardDto>>(users);
            map.Select(async x =>
            {
                var findUser = await _userManager.FindByIdAsync(x.Id);
                var userRoles = await _userManager.GetRolesAsync(findUser);
                x.RoleId = userRoles.FirstOrDefault() ?? "No Role";
                return x;
            }).ToList();
            return new SuccessDataResult<List<UserDashboardDto>>(map);

        }
        catch (Exception e)
        {
            return new ErrorDataResult<List<UserDashboardDto>>(e.Message);
        }
    }
}
