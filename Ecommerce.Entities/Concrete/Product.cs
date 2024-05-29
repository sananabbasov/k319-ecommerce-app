using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Entities.Concrete;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string  Information { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public bool IsFeatured { get; set; }
    public virtual List<Review> Reviews { get; set; }
    public virtual List<Photo> Photos { get; set; }
}
