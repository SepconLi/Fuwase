/*
	Las historias trabajadas estan relacionadas a historias que ya han sido aprobadas en sprintas anterores entonces no tenemos el Id específico de las historias
	Las personas que trabajaron en esta actividad son: Jorim G. Wilson Ellis
	Tareas implementadas: hacer testing de implementaciones anteriores(donation entity, location y statistics entity con sus respectivos servicios)
*/

/* Project includes */
using Domain.Statistics.Entities;
/* System includes */
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace UnitTests.Domain.Statistics.Entities
{
    public class StatitsticsTests
    {

		////Tests for valid statistics instance
		[Fact]
		public void StatisticsInstance()
		{
			//arrange
			var statisticsTest = new {
				User_Id = "sodalasmariposas@gmail.com",
				Donation_Amount = 0,
				Order_Amount = 0,
				Donated_Weight = 0,
			};
			var statistics = new Statistic("sodalasmariposas@gmail.com", 0, 0, 0);

			//act and assert
			statistics.Should().BeEquivalentTo(statisticsTest);
		}

		//Tests for empty statistics instance
		[Fact]
		public void StatisticsEmptyInstance()
		{
			//arrange
			var statisticsTest = new
			{
				User_Id = "",
				Donation_Amount = 0,
				Order_Amount = 0,
				Donated_Weight = 0,
			};
			var statistics = new Statistic("", 0, 0, 0);

			//act and assert
			statistics.Should().BeEquivalentTo(statisticsTest);
		}


		////Tests for donation amount greater or equal to 0 statistics instance
		[Fact]
		public void StatisticsDonationAmountEqualsGreaterThan0()
		{
			//arrange
			var statistics = new Statistic("sodalasmariposas@gmail.com", 1, 0, 0);

			//act and assert
			statistics.Donation_Amount.Should().BeGreaterThanOrEqualTo(0);
		}

		////Tests for order amount greater or equal to 0 statistics instance
		[Fact]
		public void StatisticsOrderAmountEqualsGreaterThan0()
		{
			//arrange
			var statistics = new Statistic("sodalasmariposas@gmail.com", 1, 1, 0);

			//act and assert
			statistics.Order_Amount.Should().BeGreaterThanOrEqualTo(0);
		}

		////Tests for donated weight greater or equal to 0 statistics instance
		[Fact]
		public void StatisticsDonatedWeightEqualsGreaterThan0()
		{
			//arrange
			var statistics = new Statistic("sodalasmariposas@gmail.com", 1, 1, 1.0);

			//act and assert
			statistics.Donated_Weight.Should().BeGreaterThanOrEqualTo(0);
		}
	}
}
