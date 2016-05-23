namespace EmailSender.Tests
{
    public interface IEmailSender
    {
        void SendEmail(string fromEmailAddress);
    }
}