using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Concrete;

public class User : IdentityUser
{
    public string FirsttName { get; set; }
    public string LastName { get; set; }
    public virtual List<Product> Products { get; set; }
    public virtual List<Order> Orders { get; set; }
    public virtual List<IdentityRole> Roles { get; set; }

}
