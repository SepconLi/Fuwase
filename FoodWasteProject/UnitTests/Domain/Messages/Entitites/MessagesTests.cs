using Domain.Messages.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Messages.Entitites
{
    public class MessagesTests
    {

        [Fact]
        public void createMesage()
        {

            Message messageObject = new Message(4,"ramirezjosher@gmail.com","hola");

            var messageTest = new { Id = 0, Date_Message = messageObject.Date_Message, Text = "hola", SenderId = "ramirezjosher@gmail.com", OrderId = 4 };


            //messageObject.Date_Message.Date.Should().Be(messageTest.Date_Message.Date);

            messageObject.Should().BeEquivalentTo(messageTest);

        }

        [Fact]
        public void createMessageWithDate()
        {
            var messageTest = new { Id = 1, Date_Message = new DateTime(), Text = "hola", SenderId = "ramirezjosher@gmail.com", OrderId = 4 };


            Message messageObject = new Message(1,new DateTime(),"hola","ramirezjosher@gmail.com",4);

            messageObject.Should().BeEquivalentTo(messageTest);
        }

        [Fact]
        public void isNoticeSetsCorrectly()
        {
            Message messageObject = new Message(1, new DateTime(), "[Notice]hola", "ramirezjosher@gmail.com", 4);

            messageObject.IsNotice.Should().BeTrue();
        }
        [Fact]
        public void isLocationSetsCorrectly()
        {
            Message messageObject = new Message(1, new DateTime(), "[Location]hola", "ramirezjosher@gmail.com", 4);

            messageObject.IsLocation.Should().BeTrue();
        }
        [Fact]
        public void isImageSetsCorrectly()
        {
            Message messageObject = new Message(1, new DateTime(), "[Image]hola", "ramirezjosher@gmail.com", 4);

            messageObject.IsImage.Should().BeTrue();
        }

        [Fact]
        public void messageTestId()
        {
            Message messageObject = new Message(1, new DateTime(), "[Image]hola", "ramirezjosher@gmail.com", 4);

            messageObject.Id.Should().Be(1);
        }

        [Fact]
        public void messageTestUser()
        {
            Message messageObject = new Message(1, "[Image]hola", "ramirezjosher@gmail.com");

            messageObject.SenderId.Equals("ramirezjosher@gmail.com");
        }



    }
}
