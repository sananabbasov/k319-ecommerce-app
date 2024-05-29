using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Repositories.EntityFramework;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Entities.Concrete;

namespace Ecommerce.DataAccess.Concrete.EntityFramework;

public class EfReviewDal : EfRepositoryBase<Review, AppDbContext>, IReviewDal
{
    
}