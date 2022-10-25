
using Domain.Orders.DTOs;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Orders.DTOs
{
    public class InformationDTOsTests
    {
        [Fact]
        public void createInformatioDTOWithEmailNameAndLastName()
        {
            // Arrange
            var testObject = new { Email = "a10campos@hotmail.com", Name = "Aaron", LastName = "Campos" };
            var informationDTO = new InformacionDTO("a10campos@hotmail.com", "Aaron", "Campos");

            // Act and assert
            informationDTO.Should().BeEquivalentTo(testObject);
        }


        [Fact]
        public void createInformatioDTO()
        {
            // Arrange
            InformacionDTO informationDTO = new InformacionDTO();

            // Act and assert
            informationDTO.Should();
        }

        [Fact]
        public void createInformatioDTOAnom()
        {
            // Arrange
            InformacionDTO informationDTO = new InformacionDTO("Sirlany.morag@gmail.com", "sirlany");

            // Act and assert
            informationDTO.Should();
        }
        [Fact]
        public void createinformationDTOwithEmailAndName()
        {
            string? LastName = null;
            var testObject = new { Email = "ramirezjosher@gmail.com", Name = "Josher", LastName, Anom_Preference = false };

            var informationDTO = new InformacionDTO("ramirezjosher@gmail.com", "Josher");

            informationDTO.Should().BeEquivalentTo(testObject);
        }

        [Fact]
        public void AnomPreferenceSetsCorrectly()
        {
            var testObject = new { Email = "ramirezjosher@gmail.com", Anom_Preference = false, UserName = "Enrique28" };
            var informationDTO = new InformacionDTO("ramirezjosher@gmail.com", false, "Enrique28");
            informationDTO.Should().BeEquivalentTo(testObject);
        }

    }
}
