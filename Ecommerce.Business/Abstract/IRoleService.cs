using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Entities.Dtos.RoleDtos;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Business.Abstract;

public interface IRoleService
{
    Task<IDataResult<List<IdentityRole>>> GetRoles();
    Task<IResult> CreateRole(RoleCreateDto role);
    Task<IResult> AddRole(string roleName, string userId);
}
