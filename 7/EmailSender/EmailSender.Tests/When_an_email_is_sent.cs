/*
 Install-Package Autofac
 */

using Autofac;
using Xunit;

namespace EmailSender.Tests
{
    public interface IEmailSender
    {
        void SendEmail(string fromEmailAddress);
    }

    public class EmailSender : IEmailSender
    {
        public static bool EmailHasBeenSent { set; get; }

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
            var builder = new ContainerBuilder();
            builder.RegisterType<EmailSender>().As<IEmailSender>();
            var container = builder.Build();
            IEmailSender emailSender = container.Resolve<IEmailSender>();

            //Act
            emailSender.SendEmail(fromEmailAddress);

            //Assert
            Assert.True(EmailSender.EmailHasBeenSent);
        }
    }
}