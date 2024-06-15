using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.CategoryDtos;
using Ecommerce.Entities.Dtos.ProductDtos;

namespace Ecommerce.WebUI.ViewModels;

public class HomeVm
{
    public List<CategoryHomeDto> CategoryHome { get; set; }
    public List<RecentProductDto> RecentProducts { get; set; }
    public List<SpecialOfferDto> SpecialOffers { get; set; }
}
