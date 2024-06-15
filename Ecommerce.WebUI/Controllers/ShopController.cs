using Bogus.DataSets;
using Ecommerce.Business.Abstract;
using Ecommerce.Entities.Dtos.CartDtos;
using Ecommerce.Entities.Dtos.CategoryDtos;
using Ecommerce.Entities.Dtos.ProductDtos;
using Ecommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.Controllers;

public class ShopController : Controller
{
    private readonly IProductService _productService;
    private readonly IDistributedCache _cache;

    private readonly ICategoryService _categoryService;

    public ShopController(IProductService productService, IDistributedCache cache, ICategoryService categoryService)
    {
        _productService = productService;
        _cache = cache;
        _categoryService = categoryService;
    }

    public IActionResult Index(int maxPrice,  int categoryId, int currentPage=1, int minPrice = 0)
    {  
        var products = _productService.ShopProducts(currentPage,minPrice, maxPrice, categoryId);
        var categories = _categoryService.GetHomeCategories();
        ShopVm vm = new()
        {
            Products = products,
            CategoryHome = categories 
        };
        return View(vm);
    }

    public async Task<IActionResult> Detail(int id)
    {


        var findCookie = Request.Cookies["basket"];
        if (findCookie == null)
        {
            CookieOptions cookie = new();
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddMonths(12);
            Response.Cookies.Append("basket", Guid.NewGuid().ToString(), cookie);
            findCookie = Request.Cookies["basket"];
        }

        var product = _productService.GetProductDetail(id);

        ShopDetailVm detailVm = new()
        {
            ProductDetail = product
        };
        return View(detailVm);
    }

    [HttpPost]
    public async Task<IActionResult> AddBasket(CartDto cart)
    {



        var findCookie = Request.Cookies["basket"];
        if (findCookie == null)
        {
            CookieOptions cookie = new();
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddMonths(12);
            Response.Cookies.Append("basket", Guid.NewGuid().ToString(), cookie);
            findCookie = Request.Cookies["basket"];
        }

        List<CartDto> resultcart = new();
        string basketKey = $"basket:{findCookie}";
        string find = await _cache.GetStringAsync(basketKey);
        if (find != null)
        {
            resultcart = JsonConvert.DeserializeObject<List<CartDto>>(find);
            var check = resultcart.FirstOrDefault(x => x.ProductId == cart.ProductId);
            if (check != null)
            {
                check.Quantity += cart.Quantity;
            }
            else
            {
                resultcart.Add(cart);
            }
        }
        else
        {
            resultcart.Add(cart);
        }
        var json = JsonConvert.SerializeObject(resultcart);
        await _cache.SetStringAsync(basketKey, json);
        return Ok();
    }

    public async Task<IActionResult> Cart()
    {
        var findCookie = Request.Cookies["basket"];
        string find = await _cache.GetStringAsync($"basket:{findCookie}");
        if (find == null)
        {
            return View(new List<ProductCartDto>());
        }
        var items = JsonConvert.DeserializeObject<List<CartDto>>(find);
        var cartProduct = _productService.GetProductsById(items.Select(x => x.ProductId).ToList());
        foreach (var cart in cartProduct)
        {
            cart.Quantity = items.FirstOrDefault(z => z.ProductId == cart.Id).Quantity;
        }
        return View(cartProduct);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
