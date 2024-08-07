using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Repositories;
using Ecommerce.Entities.Concrete;

namespace Ecommerce.DataAccess.Abstract;

public interface IUserDal : IRepositoryBase<User>
{
    List<User> GetUserAndRole();
}
