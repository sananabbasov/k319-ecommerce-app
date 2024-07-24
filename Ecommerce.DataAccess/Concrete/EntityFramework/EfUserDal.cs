using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Repositories.EntityFramework;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfRepositoryBase<User, AppDbContext>, IUserDal
{
    public List<User> GetUserAndRole()
    {
        using var context = new AppDbContext();

        return context.Users.Include(x=>x.Roles).ToList();
    }
}
