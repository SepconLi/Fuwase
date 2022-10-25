
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

using Application;
using Domain.Products.Repositories;
using Domain.Products.Entities;
using Infrastructure;
using Infrastructure.Products;
using Infrastructure.Products.Repositories;

/*This tests correspond to the Allergen repository and were made by Daniela Murillo */

namespace IntegrationTests.Infrastructure.Products.Repositories
{
    public class AllergenRepositoryTests
    {
        //Testing that the getCategories method returns the existing categories in the DB
        [Fact]
        public async Task GetCategoriesShouldReturnCategoriesTest()
        {
            // Act
            var builder = WebApplication.CreateBuilder();
            //The amount of categories currently in the DB
            var categoriesCount = 6;


            builder.Services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("TestConnection")));
            builder.Services.AddScoped<IAllergenRepository, AllergenRepository>();

            var app = builder.Build();

            //calls the method
            var repository = app.Services.GetRequiredService<IAllergenRepository>();

            var categories = await repository.GetCategories();

            //validates the amount of element in the category list
            categories.Should().HaveCount(categoriesCount);

        }

        //Testing that the getAllergenByCategory method returns the existing allergen for that category in the DB
        [Fact]
        public async Task GetAllergenByCategoryShouldReturnAllergensTest()
        {
            // Act
            var builder = WebApplication.CreateBuilder();
            //The amount of elements that the "Otros" category has
            var allergenCount = 2;
            string categoryName = "Otros";

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            //Calls the indicated method
            var repository = app.Services.GetRequiredService<IAllergenRepository>();

            var categories = await repository.GetAllergenByCategory(categoryName);

            //validates the amount of element in the allergen list
            categories.Should().HaveCount(allergenCount);

        }

        //Testing that the getAllergenByCategory method returns a non null value with a valid category name
        [Fact]
        public async Task GetAllergenByValidCategoryAsyncTest()
        {
            //act
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAllergenRepository>();

            //arrange
            //Calls the method with an existing category name
            var allergens = await repository.GetAllergenByCategory("Otros");

            //assert
            allergens.Should().NotBeEmpty();
        }

        //Testing that the getAllergenByCategory method returns a null value with a invalid category name
        [Fact]
        public async Task GetAllergenByInvalidCategoryAsyncTest()
        {
            //act
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IAllergenRepository>();

            //arrange
            //Calls the method with a non existing category name
            var allergens = await repository.GetAllergenByCategory("No soy categoría");

            //assert
            allergens.Should().BeNullOrEmpty();
        }

    }
}
