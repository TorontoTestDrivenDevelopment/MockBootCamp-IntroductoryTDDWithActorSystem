/*
 Install-Package xunit
 Install-Package FakeItEasy
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace EmailSender.Tests
{
    [TestClass]
    public class When_an_email_is_sent
    {
        [Fact]
        public void It_should_be_delivered()
        {
            /*
             //Arrange
             var fromEmailAddress = "from@email.com";
             var toEmailAddress = "to@email.com";

             //Act
             SendEmail(fromEmailAddress);

             //Assert
             Assert.True(EmailHasBeenSent);
              */
        }
    }
}