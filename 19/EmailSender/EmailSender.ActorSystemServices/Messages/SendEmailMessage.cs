namespace EmailSender.ActorSystemServices.Messages
{
    public class SendEmailMessage
    {
        public SendEmailMessage(string toEmailAddress, string fromEmailAddress, string subject , string body)
        {
            ToEmailAddress = toEmailAddress;
            FromEmailAddress = fromEmailAddress;
            Body = body;
            Subject = subject;
        }

        public string ToEmailAddress { get;  }
        public string FromEmailAddress { get; }
        public string Body { get; }
        public string Subject { get;   set; }
    }
}