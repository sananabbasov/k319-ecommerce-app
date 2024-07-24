using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Business.Abstract;
using Ecommerce.Business.AutoMapper;
using Ecommerce.Business.Concrete;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Business.DependencyResolver;

public static class ServiceRegistration
{
    public static void AddBusinesRegistration(this IServiceCollection services)
    {

        services.AddStackExchangeRedisCache(option =>
        {
            option.Configuration = "localhost";
            option.InstanceName = "basket";
        });

        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();


        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderDal, EfOrderDal>();


        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IProductDal, EfProductDal>();

        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserDal, EfUserDal>();

        services.AddScoped<IRoleService, RolesManager>();

  

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
