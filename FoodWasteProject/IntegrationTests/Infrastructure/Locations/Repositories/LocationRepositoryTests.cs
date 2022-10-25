using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Locations.Entities;
using Domain.Locations.Repositories;
//using Domain.Locations.ValueObjects;
using ServerFoodWaste;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Infrastructure;
using Application;

namespace IntegrationTests.Locations.Infrastructure.Repositories
{
    public class LocationRepositoryIntegrationTests
    {

        [Fact]
        public async Task GetAllAsyncShouldReturnAllProvinces()
        {
            //act
            const int ProvinceCount = 7;
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<ILocationRepository>();
            var location = new Location();
            await repository.GetProvinces();

            // arrange
            var provincesTest = await repository.GetProvinces();
            // assert
            provincesTest.Should().HaveCount(ProvinceCount);
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnAllDistricts()
        {
            
            // arrange
            const int districtCount = 6;
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<ILocationRepository>();
            await repository.GetDistricts("Limon");
            // act
            var districtsTest = await repository.GetDistricts("Limon");
            // assert
            districtsTest.Should().HaveCount(districtCount);
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnAllTowns()
        {
           // arrange
            const int townCount = 4;
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<ILocationRepository>();
            await repository.GetTowns("Limon", "Limon");
            // act
            var townsTest = await repository.GetTowns("Limon", "Limon");
            // assert
            townsTest.Should().HaveCount(townCount);
        }

    }
}