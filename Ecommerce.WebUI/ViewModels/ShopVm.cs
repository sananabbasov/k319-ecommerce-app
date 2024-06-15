using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities.Dtos.CategoryDtos;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.Entities.Payloads;

namespace Ecommerce.WebUI.ViewModels;

public class ShopVm
{
    public PaginationResponse<ProductShopDto> Products { get; set; }
    public List<CategoryHomeDto> CategoryHome { get; set; }

}
