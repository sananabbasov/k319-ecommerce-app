using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Concrete;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public virtual List<Product> Products { get; set; }
}

