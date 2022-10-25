/*
	Las historias trabajadas estan relacionadas a historias que ya han sido aprobadas en sprintas anterores entonces no tenemos el Id específico de las historias
	Las personas que trabajaron en esta actividad son: Milen Rodriguez Man y Jorim G. Wilson Ellis
	Tareas implementadas: hacer testing de implementaciones anteriores(donation entity y product entity con sus respectivos servicios)
*/

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using Domain.Products.Repositories;
using ServerFoodWaste;
using Microsoft.AspNetCore.Builder;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Application;
using Domain.Statistics.Repositories;
using Domain.Statistics.Entities;
using System;
using System.Collections.Generic;
using Infrastructure.Statistics;
using Infrastructure.Statistics.Repositories;

namespace IntegrationTests.Infrastructure.Statistics.Repositories
{
    public class StatisticsRepositoryTests
    {
        //Test to get the statistics for a valid user
        [Fact]
        public async Task GetStatisticsByUserIdAsyncTest()
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

            var repository = app.Services.GetRequiredService<IStatisticRepository>();
            await repository.GetStatisticsByUserIdAsync("sodalasmariposas@gmail.com");

            //arrange
            var donationTest = await repository.GetStatisticsByUserIdAsync("sodalasmariposas@gmail.com");

            //assert
            donationTest.Should().NotBeNull();//might return null if user is not on statistics table
        }

        //Test to get the statistics for an invalid user
        [Fact]
        public async Task GetStatisticsByInvalidUserIdAsyncTest()
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

            var repository = app.Services.GetRequiredService<IStatisticRepository>();
            await repository.GetStatisticsByUserIdAsync("joririm007@gmail.com");

            //arrange
            var donationTest = await repository.GetStatisticsByUserIdAsync("jorimrim007@gmail.com");

            //assert
            donationTest.Should().BeNull();//might not return null if user is on statistics table
        }

        //Test to get the statistics for top donors
        [Fact]
        public async Task GetTopBusinessDonorsAsyncTest()
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

            var repository = app.Services.GetRequiredService<IStatisticRepository>();
            await repository.GetTopBusinessDonors();

            //arrange
            var donationsTest = await repository.GetTopBusinessDonors(); ;

            //assert
            donationsTest.Should().NotBeNull();//might return null if there are no registered business accounts in the db
        }

        //Test to get the donations statistics for the whole app
        [Fact]
        public async Task GetTotalAppDonationsAsyncTest()
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

            var repository = app.Services.GetRequiredService<IStatisticRepository>();
            await repository.GetTotalAppDonations();

            //arrange
            var donationsTest = await repository.GetTotalAppDonations(); ;

            //assert
            donationsTest.Should().NotBeNull();//might return null if there are no registered business accounts in the db
        }
    }

}
