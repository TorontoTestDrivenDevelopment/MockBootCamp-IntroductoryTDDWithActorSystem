using System;
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

    public class TestHelper
    {
        public IContainer Register<TF,TT>(IContainer continer = null)
        {
            continer = continer ?? new ContainerBuilder().Build();
            var builder = new ContainerBuilder();
            builder.RegisterType<TF>().As<TT>();
            builder.Update(continer);
            return continer;
        }
        public IContainer Register<TT>(Func<IComponentContext,TT> resolution, IContainer continer = null)
        {
            continer = continer ?? new ContainerBuilder().Build();
            var builder = new ContainerBuilder();
            builder.Register(resolution).As<TT>();
            builder.Update(continer);
            return continer;
        }
    }

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