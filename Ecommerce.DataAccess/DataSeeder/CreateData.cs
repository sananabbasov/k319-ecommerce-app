using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Ecommerce.DataAccess.Concrete.EntityFramework;
using Ecommerce.Entities.Concrete;

namespace Ecommerce.DataAccess.DataSeeder;

public static class CreateData
{
    public static void CreateFakeData()
    {
        using var context = new AppDbContext();

        if (!context.Categories.Any())
        {
            var fakeCategories = new Faker<Category>("az");
            fakeCategories.RuleFor(x => x.Name, y => y.Commerce.Categories(1)[0]);
            var result = fakeCategories.Generate(70);
            context.Categories.AddRange(result);
            context.SaveChanges();
        }

        if (!context.Products.Any())
        {

            var bogusPhotos = new Faker<Photo>("az");
            bogusPhotos.RuleFor(x => x.Url, y => y.Image.PicsumUrl());
            var fakeProducts = new Faker<Product>("az");
            fakeProducts.RuleFor(x => x.Name, y => y.Commerce.ProductName());
            fakeProducts.RuleFor(x => x.Price, y => y.Random.Decimal(500, 4000));
            fakeProducts.RuleFor(x => x.Description, y => y.Commerce.ProductDescription());
            fakeProducts.RuleFor(x => x.DiscountPrice, y => y.Random.Decimal(0, 500));
            fakeProducts.RuleFor(x => x.Information, y => y.Commerce.ProductMaterial());
            fakeProducts.RuleFor(x => x.Stock, y => y.Random.Int(30, 400));
            fakeProducts.RuleFor(x => x.CategoryId, y => y.Random.Int(1, 30));
            fakeProducts.RuleFor(x => x.Photos, y => bogusPhotos.Generate(5));
            var result = fakeProducts.Generate(700);
            context.Products.AddRange(result);
            context.SaveChanges();
        }
    }
}
