using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Dtos.UserDtos;

public class UserDashboardDto
{
    public string Id { get; set; }
    public string FirsttName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string NormalizedEmail { get; set; }
    public string? RoleId { get; set; }
}
