/*
	Las historias trabajadas estan relacionadas a historias que ya han sido aprobadas en sprintas anterores entonces no tenemos el Id específico de las historias
	Las personas que trabajaron en esta actividad son: Jorim G. Wilson Ellis
	Tareas implementadas: hacer testing de implementaciones anteriores(donation entity, location y statistics entity con sus respectivos servicios)
*/

using System.Collections.Generic;
//Project imports
using Domain.Locations.Entities;
using Domain.Locations.Repositories;
using Application.Users.Implementations;
//Nugets imports
using Xunit;
using FluentAssertions;
using Moq;
using System.Linq;
using Application.Locations.Implementations;

namespace UnitTests.Application.Locations
{
    public class LocationServiceTests
    {
        private static readonly string ProvinceName = "Province name";

        private static readonly string DistrictName = "District name";

        private static readonly string TownName = "Town name";

        private static IEnumerable<Province> GetProvinces()
        {
            const int provinceCount = 7;
            for (int i = 0; i < provinceCount; ++i)
            {
                yield return new Province(ProvinceName);
            }
        }

       private static IEnumerable<District> GetDistricts()
        {
            const int districtCount = 7;
            for (int i = 0; i < districtCount; ++i)
            {
                yield return new District(ProvinceName, DistrictName);
            }
        }

        private static IEnumerable<Town> GetTowns()
        {
            const int townCount = 7;
            for (int i = 0; i < townCount; ++i)
            {
                yield return new Town(ProvinceName, DistrictName, TownName);
            }
        }

        [Fact]
        public async void GetProvincesAsyncShouldReturnProvinces()
        {
            // arrange
            var provinces = GetProvinces().ToList();
            var mockLocationRepository = new Mock<ILocationRepository>();
            mockLocationRepository.Setup(repo =>
            repo.GetProvinces()).ReturnsAsync(provinces);

            var locationService = new LocationService(mockLocationRepository.Object);
            // act
            var results = await locationService.GetProvincesAsync();
            // assert
            results.Should().BeEquivalentTo(provinces);
        }

        [Fact]
        public async void GetDistrictsAsyncShouldReturnDistricts()
        {
            // arrange
            var provinces = GetProvinces().ToList();
            var districts = GetDistricts().ToList();
            var mockLocationRepository = new Mock<ILocationRepository>();
            mockLocationRepository.Setup(repo =>
            repo.GetDistricts(ProvinceName)).ReturnsAsync(districts);
            var locationService = new LocationService(mockLocationRepository.Object);
            // act
            var results = await locationService.GetDistrictsAsync(ProvinceName);
            // assert
            results.Should().BeEquivalentTo(districts);
        }

        [Fact]
        public async void GetTownsAsyncShouldReturnTowns()
        {
            // arrange
            var provinces = GetProvinces().ToList();
            var districts = GetDistricts().ToList();
            var towns = GetTowns().ToList();
            var mockLocationRepository = new Mock<ILocationRepository>();
            mockLocationRepository.Setup(repo =>
            repo.GetTowns(ProvinceName, DistrictName)).ReturnsAsync(towns);
            var locationService = new LocationService(mockLocationRepository.Object);
            // act
            var results = await locationService.GetTownsAsync(ProvinceName, DistrictName);
            // assert
            results.Should().BeEquivalentTo(towns);
        }
    }
}