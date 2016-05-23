namespace EmailSender.ActorSystemServices.Messages
{
    public class SendEmailMessage
    {
        public SendEmailMessage(string toEmailAddress)
        {
            ToEmailAddress = toEmailAddress;
        }

        public string ToEmailAddress { get; }
    }
}