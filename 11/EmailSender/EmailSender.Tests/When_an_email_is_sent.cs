using Autofac;
using Xunit;

namespace EmailSender.Tests
{
    public class When_an_email_is_sent
    {
        public When_an_email_is_sent()
        {
            TestHelper = new TestHelper();
            Container = TestHelper.Register<EmailSender,IEmailSender>();
        }

        public IContainer Container { get; set; }
        public TestHelper TestHelper { set; get; }

        [Fact]
        public void It_should_be_delivered()
        {
            //Arrange
            var fromEmailAddress = "from@email.com";
            var toEmailAddress = "to@email.com";
            var emailSender = Container.Resolve<IEmailSender>();

            //Act
            emailSender.SendEmail(fromEmailAddress);

            //Assert
            Assert.True(EmailSender.EmailHasBeenSent);
        }
    }
}