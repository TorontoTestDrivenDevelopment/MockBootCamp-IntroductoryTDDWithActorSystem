using Akka.Actor;
using EmailSender.ActorSystemServices.Messages;
using EmailSender.EmailServices;

namespace EmailSender.ActorSystemServices.Actors
{
    public class EmailSenderActor : ReceiveActor
    {
        public EmailSenderActor(IEmailSender emailSender)
        {
            Receive<SendEmailMessage>(message =>
            {
                emailSender.SendEmail(message.ToEmailAddress);
                Sender.Tell(new EmailMessageSent());
            });
        }
    }
}