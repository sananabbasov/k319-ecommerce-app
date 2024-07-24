using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Utilities.Results.Abstract;
using Ecommerce.Entities.Dtos.UserDtos;

namespace Ecommerce.Business.Abstract;

public interface IUserService
{
    Task<IDataResult<List<UserDashboardDto>>> GetDashboardUsers();
    Task<IResult> AddRole(UserAddRoleDto userAddRoleDto);
}
