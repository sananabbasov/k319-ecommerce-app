using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Ecommerce.DataAccess.Concrete.EntityFramework;
using Ecommerce.Entities.Concrete;
using Ecommerce.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.DataAccess.DataSeeder;

public static class CreateData
{

    public static void CreateFakeData()
    {
        using var context = new AppDbContext();


        if (!context.Users.Any())
        {
            var fakerUsers = new Faker<User>("az");
            fakerUsers.RuleFor(x => x.FirsttName, y => y.Name.FirstName());
            fakerUsers.RuleFor(x => x.LastName, y => y.Name.LastName());
            fakerUsers.RuleFor(x => x.UserName, y => y.Internet.UserName() + y.Random.Number(1, 800000));
            fakerUsers.RuleFor(x => x.NormalizedEmail, y => y.Internet.Email());
            fakerUsers.RuleFor(x => x.NormalizedUserName, y => y.Internet.UserName() + y.Random.Number(1, 800000));
            fakerUsers.RuleFor(x => x.EmailConfirmed, y => y.Random.Bool());
            fakerUsers.RuleFor(x => x.PasswordHash, y => y.Internet.Password());
            fakerUsers.RuleFor(x => x.SecurityStamp, y => y.Internet.Password());
            fakerUsers.RuleFor(x => x.ConcurrencyStamp, y => y.Internet.Password());

            var result = fakerUsers.Generate(400);
            context.Users.AddRange(result);
            context.SaveChanges();

        }

        if (!context.Orders.Any())
        {


            var users = context.Users.ToList();

            var fakerOrder = new Faker<Order>();
            fakerOrder.RuleFor(x => x.TotalPrice, y => y.Random.Decimal(500, 4000));
            fakerOrder.RuleFor(x => x.DeliveryAddress, y => y.Address.City());
            fakerOrder.RuleFor(x => x.PhoneNumber, y => y.Internet.Email());
            fakerOrder.RuleFor(x => x.OrderDate, y => y.Date.Between(DateTime.Now, DateTime.Now));
            fakerOrder.RuleFor(x => x.DeliveryStatus, y => y.Random.Enum<DeliveryStatus>());
            fakerOrder.RuleFor(x => x.UserId, y => users[y.Random.Number(2, 399)].Id);

            var orderRes = fakerOrder.Generate(5000);
            context.Orders.AddRange(orderRes);
            context.SaveChanges();
        }

        if (!context.Reviews.Any())
        {


            var users = context.Users.ToList();
            var products = context.Products.ToList();

            var reviewOrder = new Faker<Review>();
            reviewOrder.RuleFor(x => x.Point, y => y.Random.Double(1, 5));
            reviewOrder.RuleFor(x => x.Message, y => y.Rant.Reviews()[0]);
            reviewOrder.RuleFor(x => x.UserId, y => users[y.Random.Number(2, 399)].Id);
            reviewOrder.RuleFor(x => x.ProductId, y => products[y.Random.Number(1, 699)].Id);
            var orderRes = reviewOrder.Generate(7000);
            context.Reviews.AddRange(orderRes);
            context.SaveChanges();
        }


        if (!context.OrderItems.Any())
        {
            var fakerOrderItems = new Faker<OrderItem>();
            fakerOrderItems.RuleFor(x => x.OrderId, y => y.Random.Number(1, 5000));
            fakerOrderItems.RuleFor(x => x.ProductId, y => y.Random.Number(1, 700));
            fakerOrderItems.RuleFor(x => x.Price, y => y.Random.Decimal(500, 4000));
            fakerOrderItems.RuleFor(x => x.DiscountPrice, y => y.Random.Decimal(0, 500));
            var resOrderItems = fakerOrderItems.Generate(2000);
            context.OrderItems.AddRange(resOrderItems);
            context.SaveChanges();
        }


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
