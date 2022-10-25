using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Donations.Implementations;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Donations.DTOs;
using Domain.Donations.Entities;
using Domain.Donations.Repositories;
using Moq;
using Xunit;
using Application.Donations;
using Domain.Products.Entities;
using System;

namespace UnitTests.Application.Donations
{
    public class DonationServiceTests
    {
        private static IList<Donation> GetDonations()
        {
            IList<Donation> donations = new List<Donation>();
            var donation01 = new Donation();
            donation01.DonorId = "milen.rodrig.m@gmail.com";
            donation01.Products.Append(new Product("name", "foodType", "prodType",
            DateTime.Today, 2, 2,
            donation01, null, "brand",
            new List<Restriction>(), donation01.Id));

            var donation02 = new Donation();
            donation02.DonorId = "milen.rodrig.m@gmail.com";
            donation02.Products.Append(new Product("name", "foodType", "prodType",
            DateTime.Today, 2, 2,
            donation02, null, "brand",
            new List<Restriction>(), donation02.Id));

            var donation03 = new Donation();
            donation03.DonorId = "milen.rodrig.m@gmail.com";
            donation03.Products.Append(new Product("name", "foodType", "prodType",
            DateTime.Today, 2, 2,
            donation03, null, "brand",
            new List<Restriction>(), donation03.Id));

            var donation04 = new Donation();
            donation04.DonorId = "milen.rodrig.m@gmail.com";
            donation04.Products.Append(new Product("name", "foodType", "prodType",
            DateTime.Today, 2, 2,
            donation04, null, "brand",
            new List<Restriction>(), donation04.Id));

            donations.Add(donation01);
            donations.Add(donation02);
            donations.Add(donation03);
            donations.Add(donation04);

            return donations;
        }

        private static IList<DonationDTO> GetDonationsDTO()
        {
            IList<DonationDTO> donations = new List<DonationDTO>();
            var donationDummy = GetDonations().First();
            IReadOnlyCollection<Product> products = new List<Product>();
            products.Append(new Product("name", "foodType", "prodType",
            DateTime.Today, 2, 2,
            donationDummy, null, "brand",
            new List<Restriction>(), donationDummy.Id));
            var donation01 = new DonationDTO(1, "milen.rodrig.m@gmail.com", products);
            var donation02 = new DonationDTO(1, "milen.rodrig.m@gmail.com", products);

            var donation03 = new DonationDTO(1, "milen.rodrig.m@gmail.com", products);

            var donation04 = new DonationDTO(1, "milen.rodrig.m@gmail.com", products);

            donations.Add(donation01);
            donations.Add(donation02);
            donations.Add(donation03);
            donations.Add(donation04);

            return donations;
        }

        /*
        [Fact]
        public async Task AddValidDonationAsyncShouldAddDonation()
        {
            // arrange
            var donationTest = new Donation(1, "Provincia", "Canton", "Distrito"
				, "JuanTalameda", "Muy buena comida", "milen.rodrig.m@gmail.com");
            
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.AddDonationAsync(donationTest));
            mockDonationRepository.Setup(repo => repo.GetByIdAsync(donationTest.Id)).Returns(Task.FromResult<Donation?>(donationTest));

            var donationService = new DonationService(mockDonationRepository.Object);
            // act
            await donationService.AddDonationAsync(donationTest);
            var result = await donationService.GetByIdAsync(donationTest.Id);
            
            // assert
            result.Should().Be(donationTest);

        }

        [Fact]
        public async Task GetByValidIdAsyncShouldReturnDonation()
        {
            // arrange
            var donation = GetDonations()[0];
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.GetByIdAsync(donation.Id)).ReturnsAsync(donation);
            var donationService = new DonationService(mockDonationRepository.Object);

            // act
            var result = await donationService.GetByIdAsync(donation.Id);

            //assert
            result.Should().Be(donation);
        }

        [Fact]
        public async Task GetByInValidIdAsyncShouldReturnDonation()
        {
            // arrange
            var donation = GetDonations()[0];
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.GetByIdAsync(donation.Id)).ReturnsAsync(donation);
            var donationService = new DonationService(mockDonationRepository.Object);

            // act
            var result = await donationService.GetByIdAsync(3000);

            //assert
            result.Should().NotBe(donation);
        }

        [Fact]
        public async Task GetAllDonationsWithProductsAsyncShouldReturnProducts()
        {
            // arrange
            var donations = GetDonationsDTO();
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.GetAllDonationsWithProductsAsync()).Returns(Task.FromResult<IEnumerable<DonationDTO>>(donations));
            var donationService = new DonationService(mockDonationRepository.Object);

            // act
            var result = await donationService.GetAllDonationsWithProductsAsync();

            //assert
            result.Should().BeEquivalentTo(donations);
        }

        [Fact]
        public async Task GetDonationAsyncShouldReturnDonation()
        {
            // arrange
            var donation = GetDonationsDTO();
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.GetAllAsync()).Returns(Task.FromResult<IEnumerable<DonationDTO>>(donation));
            var donationService = new DonationService(mockDonationRepository.Object);

            // act
            var result = await donationService.GetDonationAsync();

            //assert
            result.Should().BeEquivalentTo(donation);
        }

        [Fact]
        public async Task ModifyDonationAsyncShouldModifyDonation()
        {
            // arrange
            var donation = GetDonations().First();
            donation.Description = "Test";
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.ModifyDonationAsync(donation));
            var donationService = new DonationService(mockDonationRepository.Object);
            //await donationService.AddDonationAsync(donation);
            
            
            // act
            await donationService.ModifyDonationAsync(donation);

            //assert
            //result.Description.Should().Be(donation.Description);//porque es nulo?
            mockDonationRepository.Verify(repo => repo.ModifyDonationAsync(donation), Times.Once);
        }

        [Fact]
        public async Task GetDonationsByValidUserIdShouldReturnDonation()
        {
            // arrange
            var donations = GetDonations();
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.GetDonationsByUserId("milen.rodrig.m@gmail.com"));
            var donationService = new DonationService(mockDonationRepository.Object);

            // act
            var result = await donationService.GetDonationsByUserId("milen.rodrig.m@gmail.com");

            //assert
            foreach (var donation in result)
            {
                donation.DonorId.Should().Be("milen.rodrig.m@gmail.com");
            }
        }

        [Fact]
        public async Task GetDonationsByInvalidUserIdShouldNotReturnDonation()
        {
            // arrange
            var donations = GetDonations();
            var mockDonationRepository = new Mock<IDonationRepository>();
            mockDonationRepository.Setup(repo => repo.GetDonationsByUserId("email@gmail.com"));
            var donationService = new DonationService(mockDonationRepository.Object);

            // act
            var result = await donationService.GetDonationsByUserId("email@gmail.com");

            //assert
            result.Should().BeEmpty();
        }
        */
    }
}