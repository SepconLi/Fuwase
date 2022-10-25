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
using Domain.Donations.Repositories;
using Domain.Donations.Entities;
using Domain.Products.Entities;
using System;
using System.Collections.Generic;
using Infrastructure.Donations;
using Infrastructure.Donations.Repositories;

namespace IntegrationTests.Infrastructure.Donations.Repositories
{
    public class DonationRepositoryTests 
    {
        [Fact]
        public async Task AddDonationAsyncTest()
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

            var repository = app.Services.GetRequiredService <IDonationRepository>();
            var donation =  new Donation("Provincia", "Canton", "Distrito"
                , "JuanTalameda", "Muy buena comida", "sodalasmariposas@gmail.com");

            donation.Products.Append(new Product("name", "foodType", "prodType",
            DateTime.Today, 2, 2,
            donation, null,"brand",
            new List<Restriction>(), donation.Id));
            await repository.AddDonationAsync(donation);

            //arrange
            var donationTest = await repository.GetByIdAsync(donation.Id);

            //assert
            donationTest.Should().Be(donation);
        }

        [Fact]
        public async Task GetDonationByIdAsyncTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();
            await repository.GetByIdAsync(2002);

            //arrange
            var donationTest = await repository.GetByIdAsync(2002);

            //assert
            donationTest.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAllDonationsWithProductsAsyncTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();
            await repository.GetAllDonationsWithProductsAsync();

            //arrange
            var donationsTest = await repository.GetAllDonationsWithProductsAsync(); ;

            //assert
            foreach (var donation in donationsTest)
            {
                donation.Products.First().Should().NotBeNull();
            }
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            //act
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();


            builder.Services.AddDbContext<DonationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("TestConnection")));
            builder.Services.AddScoped<IDonationRepository, DonationRepository>();

           // builder.Services.AddInfrastructureLayer(builder.Configuration.GetConnectionString("TestConnection"));
            builder.Services.AddApplicationLayer();
            builder.Services.AddSignalR();

            var app = builder.Build();

            var repository = app.Services.GetRequiredService<IDonationRepository>();
            var donations = await repository.GetAllAsync();

            //arrange
            var donationTest = await repository.GetAllAsync();
            int donationAmount = donations.Length();

            //assert
            donationTest.Length().Should().Be(donationAmount);
        }

        [Fact]
        public async Task ModifyDonationAsyncTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();
            var donation = await repository.GetByIdAsync(2002);
            donation.Description = "Test";
            await repository.ModifyDonationAsync(donation);

            //arrange
            var donationTest = await repository.GetByIdAsync(2002);
            donationTest.Description = "Hola";
            await repository.ModifyDonationAsync(donationTest);

            //assert
            donationTest.Description.Should().Be("Hola");
        }

        [Fact]
        public async Task GetDonationByValidUserIdAsyncTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();
            //var donations = await repository.GetDonationsByUserId("milen.rodrig.m@gmail.com");

            //arrange
            var donationsTest = await repository.GetDonationsByUserId("milen.rodrig.m@gmail.com");
            //int donationAmount = donations.Length();

            //assert
            foreach (var donation in donationsTest)
            {
                donation.DonorId.Should().Be("milen.rodrig.m@gmail.com");
            }
            //donationTest.Length().Should().Be(donationAmount);
        }

        [Fact]
        public async Task GetDonationByInvalidUserIdAsyncTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();
            //var donations = await repository.GetDonationsByUserId("milen.rodrig.m@gmail.com");

            //arrange
            var donationsTest = await repository.GetDonationsByUserId("milen.rodrig.m@gmail.com");
            //int donationAmount = donations.Length();

            //assert
            donationsTest.Should().BeEmpty();
        }

        [Fact]
        public async Task SetDonationStatusAsyncTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();

            //arrange
            var donation = await repository.GetByIdAsync(2002);
            donation.Status = "A";
            await repository.SetDonationStatusAsync(donation.Id);
            donation.Status = "D";
            await repository.SetDonationStatusAsync(donation.Id);
            //var donation = await repository.GetByIdAsync(2002);

            //assert
            donation.Status.Should().Be("D");
        }

        [Fact]
        public async Task HandleExistingDonationDeleteTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();

            //arrange
            var donationTest = await repository.GetByIdAsync(2008);
            if (donationTest != null) { 
                await repository.HandleDonationDelete(donationTest.Id);
            }
            donationTest = await repository.GetByIdAsync(2008);
            //assert
            donationTest.Should().BeNull();
        }

        [Fact]
        public async Task HandleNonExistingDonationDeleteTest()
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

            var repository = app.Services.GetRequiredService<IDonationRepository>();

            //arrange
            var donationTest = await repository.GetByIdAsync(3000);
            if (donationTest != null)
            {
                await repository.HandleDonationDelete(donationTest.Id);
            }
            

            //assert
            donationTest.Should().BeNull();
        }

    }

}
