namespace EmailSender.EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(string fromEmailAddress);
    }
}