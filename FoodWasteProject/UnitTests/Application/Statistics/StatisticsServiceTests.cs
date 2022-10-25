/*
	Las historias trabajadas estan relacionadas a historias que ya han sido aprobadas en sprintas anterores entonces no tenemos el Id específico de las historias
	Las personas que trabajaron en esta actividad son: Jorim G. Wilson Ellis
	Tareas implementadas: hacer testing de implementaciones anteriores(donation entity, location y statistics entity con sus respectivos servicios)
*/

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Statistics.Implementations;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Statistics.DTOs;
using Domain.Statistics.Entities;
using Domain.Statistics.Repositories;
using Moq;
using Xunit;
using Application.Statistics;
using Domain.Products.Entities;
using System;

namespace UnitTests.Application.Donations
{
    public class StatisticsServiceTests
    {
        //Dummy method to create statistics list
        private static IList<Statistic> GetStatistics()
        {
            IList<Statistic> statistics = new List<Statistic>();
            var statistic01 = new Statistic("sodalasmariposas@gmail.com", 0, 0, 0);
            var statistic02 = new Statistic("userrodriguez@gmail.com", 0, 0, 0);
            var statistic03 = new Statistic("userJuarez@gmail.com", 0, 0, 0);
            var statistic04 = new Statistic("administrator123456@gmail.com", 0, 0, 0);

            statistics.Add(statistic01);
            statistics.Add(statistic02);
            statistics.Add(statistic03);
            statistics.Add(statistic04);

            return statistics;
        }
            //Dummy method to create statistics IEnumerable
            private static IEnumerable<Statistic> GetStatisticsEnumerable()
            {
                IEnumerable<Statistic> statistics = new List<Statistic>();
                var statistic01 = new Statistic("sodalasmariposas@gmail.com", 0, 0, 0);
                var statistic02 = new Statistic("userrodriguez@gmail.com", 0, 0, 0);
                var statistic03 = new Statistic("userJuarez@gmail.com", 0, 0, 0);
                var statistic04 = new Statistic("administrator123456@gmail.com", 0, 0, 0);

                statistics.Append(statistic01);
                statistics.Append(statistic02);
                statistics.Append(statistic03);
                statistics.Append(statistic04);

                return statistics;
            }

            //Tests for retrieving statistics for a valid user
            [Fact]
        public async Task GetStatisticsByValidUserIdAsyncShouldReturnStatistics()
        {
            // arrange
            var statistic = GetStatistics()[0];
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetStatisticsByUserIdAsync(statistic.User_Id)).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var result = await statisticsService.GetStatisticsByUserIdAsync(statistic.User_Id);

            //assert
            result.Should().Be(statistic);
        }

        //Tests for retrieving statistics for an invalid user
        [Fact]
        public async Task GetByInValidUserIdAsyncShouldNotReturnStatistics()
        {
            // arrange
            var statistic = GetStatistics()[0];
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetStatisticsByUserIdAsync(statistic.User_Id)).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var result = await statisticsService.GetStatisticsByUserIdAsync("jorimrim007@gmail.com");

            //assert
            result.Should().BeNull();
        }

        //Tests for retrieving top business user for any existing one's
        [Fact]
        public async Task GetTopBusinessDonorsReturnStatisticsTopDonorsTestIfDBHasThem()
        {
            // arrange
            var statistic = GetStatisticsEnumerable();
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetTopBusinessDonors()).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var result = await statisticsService.GetTopBusinessDonors();

            //assert
            result.Should().NotBeNullOrEmpty(); // might be null if there are no business donors on the db table
        }

        //Tests for retrieving top business user when there aren't existing one's
        [Fact]
        public async Task GetTopBusinessDonorsReturnStatisticsTopDonorsTestIfDBDontHaveThem()
        {
            // arrange
            var statistic = GetStatisticsEnumerable();
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetTopBusinessDonors()).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var result = await statisticsService.GetTopBusinessDonors();

            //assert
            result.Should().BeNullOrEmpty(); // might not be null if there are no business donors on the db table
        }

        //Tests for retrieving total app donations
        [Fact]
        public async Task GetTotalAppDonationsTest()
        {
            // arrange
            var statistic = GetStatistics()[0];
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetTotalAppDonations()).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var result = await statisticsService.GetTotalAppDonations();

            //assert
            result.Should().NotBeNull(); // might be null if there are no business donors on the db table
        }

        [Fact]
        //Test if the ranking of a user with zero donations is Bronze
        //Developer: Emmanuel Zúñiga, Nathan Miranda
        public async Task GetUserRankingWithZeroDonationsShouldReturnBronze()
        {
            // Arrange
            var statistic = new Statistic("PruebaUsuario@gmail.com", 0, 0, 0);
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetStatisticsByUserIdAsync(statistic.User_Id)).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var ranking = await statisticsService.GetUserRanking(statistic.User_Id);
            var rank = ranking.Item1;
            var rankMedal = ranking.Item2;

            // Assert
            rank.Should().Be("Bronce");
            rankMedal.Should().Be("../images/bronze-medal.png");
        }

        [Fact]
        //Test if the ranking of a user with Ten donations is Silver
        //Developer: Emmanuel Zúñiga, Nathan Miranda
        public async Task GetUserRankingWithTenDonationsShouldReturnBronze()
        {
            // Arrange
            var statistic = new Statistic("PruebaUsuario@gmail.com", 10, 0, 0);
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetStatisticsByUserIdAsync(statistic.User_Id)).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var ranking = await statisticsService.GetUserRanking(statistic.User_Id);
            var rank = ranking.Item1;
            var rankMedal = ranking.Item2;

            // Assert
            rank.Should().Be("Plata");
            rankMedal.Should().Be("../images/silver-medal.png");
        }

        [Fact]
        //Test if the ranking of a user with 15 donations is Gold
        //Developer: Emmanuel Zúñiga, Nathan Miranda
        public async Task GetUserRankingWithFifTeenDonationsShouldReturnBronze()
        {
            // Arrange
            var statistic = new Statistic("PruebaUsuario@gmail.com", 15, 0, 0);
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetStatisticsByUserIdAsync(statistic.User_Id)).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var ranking = await statisticsService.GetUserRanking(statistic.User_Id);
            var rank = ranking.Item1;
            var rankMedal = ranking.Item2;

            // Assert
            rank.Should().Be("Oro");
            rankMedal.Should().Be("../images/gold-medal.png");
        }

        [Fact]
        //Test if the ranking of a user with 25 donations is Platinum
        //Developer: Emmanuel Zúñiga, Nathan Miranda
        public async Task GetUserRankingWithTwentyFiveDonationsShouldReturnBronze()
        {
            // Arrange
            var statistic = new Statistic("PruebaUsuario@gmail.com", 25, 0, 0);
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetStatisticsByUserIdAsync(statistic.User_Id)).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var ranking = await statisticsService.GetUserRanking(statistic.User_Id);
            var rank = ranking.Item1;
            var rankMedal = ranking.Item2;

            // Assert
            rank.Should().Be("Platino");
            rankMedal.Should().Be("../images/platinum-medal.png");
        }

        [Fact]
        //Test if the ranking of a user with 30 donations is Diamond
        //Developer: Emmanuel Zúñiga, Nathan Miranda
        public async Task GetUserRankingWithThirtyDonationsShouldReturnBronze()
        {
            // Arrange
            var statistic = new Statistic("PruebaUsuario@gmail.com", 30, 0, 0);
            var mockStatisticRepository = new Mock<IStatisticRepository>();
            mockStatisticRepository.Setup(repo => repo.GetStatisticsByUserIdAsync(statistic.User_Id)).ReturnsAsync(statistic);
            var statisticsService = new StatisticService(mockStatisticRepository.Object);

            // act
            var ranking = await statisticsService.GetUserRanking(statistic.User_Id);
            var rank = ranking.Item1;
            var rankMedal = ranking.Item2;

            // Assert
            rank.Should().Be("Diamante");
            rankMedal.Should().Be("../images/diamond-medal.png");
        }
    }
}