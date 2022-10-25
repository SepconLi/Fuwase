///* Project includes */
//using Domain.Products.Entities;
///* System includes */
//using FluentAssertions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace UnitTests.Domain.Products.Entities
//{
//    public class RestrictionTests
//    {
//        /************************* EMPTY CONSTRUCTOR *************************/

//        [Fact]
//        public void RestrictionTestEmptyFoodRestriction()
//        {
//            // Arrange
//            var restriction = new Restriction();

//            // Act and assert
//            restriction.FoodRestriction.Should().Be("");
//        }

//        [Fact]
//        public void RestrictionTestEmptyDonationId()
//        {
//            // Arrange
//            var restriction = new Restriction();

//            // Act and assert
//            restriction.DonationId.Should().Be(0);
//        }

//        [Fact]
//        public void RestrictionTestEmptyProductName()
//        {
//            // Arrange
//            var restriction = new Restriction();

//            // Act and assert
//            restriction.ProductName.Should().Be("");
//        }

//        //[Fact]
//        //public void RestrictionTestEmptyProduct()
//        //{
//        //    // Arrange
//        //    var restriction = new Restriction();

//        //    // Act and assert
//        //    restriction.FoodRestriction.Should().Be(null);
//        //}

//        //[Fact]
//        //public void RestrictionTestEmptyInstance()
//        //{
//        //    // arrange
//        //    var restrictionTest = new
//        //    {
//        //        FoodRestriction = "",
//        //        DonationId = 0,
//        //        ProductName = "",
//        //        Product = null
//        //    };

//        //    var restriction = new Restriction();

//        //    // act and assert
//        //    restriction.Should().BeEquivalentTo(restrictionTest);
//        //}


//        /************************* OTHER CONSTRUCTOR *************************/

//        [Fact]
//        public void RestrictionTestFoodRestriction()
//        {
//            // Arrange
//            var restriction = new Restriction("foodRestriction");

//            // Act and assert
//            restriction.FoodRestriction.Should().Be("foodRestriction");
//        }

//        //[Fact]
//        //public void RestrictionTestEmptyDonationId()
//        //{
//        //    // Arrange
//        //    var restriction = new Restriction();

//        //    // Act and assert
//        //    restriction.DonationId.Should().Be(0);
//        //}

//        //[Fact]
//        //public void RestrictionTestEmptyProductName()
//        //{
//        //    // Arrange
//        //    var restriction = new Restriction();

//        //    // Act and assert
//        //    restriction.ProductName.Should().Be("");
//        //}

//        //[Fact]
//        //public void RestrictionTestEmptyProduct()
//        //{
//        //    // Arrange
//        //    var restriction = new Restriction();

//        //    // Act and assert
//        //    restriction.FoodRestriction.Should().Be(null);
//        //}

//    }
//}
