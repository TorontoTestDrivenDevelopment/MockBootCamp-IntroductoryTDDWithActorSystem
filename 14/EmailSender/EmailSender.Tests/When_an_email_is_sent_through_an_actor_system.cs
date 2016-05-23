using Autofac;
using EmailSender.EmailServices;
using FakeItEasy;
using Xunit;

namespace EmailSender.Tests
{
    public class When_an_email_is_sent_through_an_actor_system
    {
        public When_an_email_is_sent_through_an_actor_system()
        {
            TestHelper = new TestHelper();
            FakeEmailSender = A.Fake<IEmailSender>();
            Container = TestHelper.Register((c) => FakeEmailSender);
        }

        public IContainer Container { get; set; }
        public TestHelper TestHelper { set; get; }
        public IEmailSender FakeEmailSender { set; get; }

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
            A.CallTo(() => FakeEmailSender.SendEmail(null)).WithAnyArguments().MustHaveHappened();
        }
    }
}