/*
	Unit testing of the Province stats class, testing the creation of the ProvinceStats units
	Developer: Rodrigo Li
	Team: ALV
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
    public class ProvinceStatsTests
    {
		////Tests for valid statistics instance
		[Fact]
		public void PStatInstance()
		{
			//arrange
			var PstatsTests = new
			{
				Name = "San Jose",
				Donations = 60
			};
			var Pstats = new ProvinceStats("San Jose", 60);

			//act and assert
			Pstats.Should().BeEquivalentTo(PstatsTests);
		}

		//Tests for empty statistics instance
		[Fact]
		public void PStatEmptyInstance()
		{
			//arrange
			var PstatsTests = new
			{
				Name = "",
				Donations = 0,
			};
			var Pstats = new ProvinceStats("", 0);

			//act and assert
			Pstats.Should().BeEquivalentTo(PstatsTests);

		}



	}
}
