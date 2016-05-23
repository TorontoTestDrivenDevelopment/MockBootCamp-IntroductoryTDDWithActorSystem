using Xunit;

namespace EmailSender.Tests
{
    public class EmailSender
    {
        public bool EmailHasBeenSent { set; get; }

        public void SendEmail(string fromEmailAddress)
        {
            EmailHasBeenSent = true;
        }
    }

    public class When_an_email_is_sent
    {
        [Fact]
        public void It_should_be_delivered()
        {
            //Arrange
            var fromEmailAddress = "from@email.com";
            var toEmailAddress = "to@email.com";
            EmailSender emailSender = new EmailSender();

            //Act
            emailSender.SendEmail(fromEmailAddress);

            //Assert
            Assert.True(emailSender.EmailHasBeenSent);
        }
    }
}