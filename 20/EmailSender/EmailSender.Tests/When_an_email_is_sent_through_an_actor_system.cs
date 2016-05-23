/*
 Install-Package Akka.Serialization.Wire -pre
 Install-Package Akka.Remote
 */
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;
using EmailSender.ActorSystemServices.Actors;
using EmailSender.ActorSystemServices.Messages;
using EmailSender.EmailServices;
using FakeItEasy;
using System;
using Xunit;

namespace EmailSender.Tests
{
    public class When_an_email_is_sent_through_an_actor_system
    {
        public IContainer Container { get; set; }
        public TestHelper TestHelper { set; get; }
        public IEmailSender FakeEmailSender { set; get; }

        public When_an_email_is_sent_through_an_actor_system()
        {
            TestHelper = new TestHelper();
            FakeEmailSender = A.Fake<IEmailSender>();
            Container = TestHelper.Register((c) => FakeEmailSender);
            Container = TestHelper.Register<EmailSenderActor>(Container);
        }

        [Fact]
        public void It_should_be_delivered()
        {
            //Arrange
            const string fromEmailAddress = "from@email.com";
            const string toEmailAddress = "to@email.com";
            const string subject = "Hello";
            const string body = "hello";

            var system = ActorSystem.Create("MyActorSystem");
            var propsResolver = new AutoFacDependencyResolver(Container, system);
            var emailSenderActorRef = system.ActorOf(system.DI().Props<EmailSenderActor>(), "EmailSenderActor");

            //Act
            emailSenderActorRef.Ask(new SendEmailMessage(toEmailAddress, fromEmailAddress, subject, body), TimeSpan.FromSeconds(3)).Wait();

            //Assert
            A.CallTo(() => FakeEmailSender.SendEmail(toEmailAddress, fromEmailAddress, subject, body)).MustHaveHappened();
        }
    }
}