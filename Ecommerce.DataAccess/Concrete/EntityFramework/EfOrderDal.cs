using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Repositories.EntityFramework;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class EfOrderDal : EfRepositoryBase<Order, AppDbContext>, IOrderDal
{
    public List<Order> GetDashboardOrders()
    {
        using var context = new AppDbContext();

        return context.Orders.Include(x => x.User).Where(x => x.DeliveryStatus != DeliveryStatus.DELIVERED).ToList();
    }
}
