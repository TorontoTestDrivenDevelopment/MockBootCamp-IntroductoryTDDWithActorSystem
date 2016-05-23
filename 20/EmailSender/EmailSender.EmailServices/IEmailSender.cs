namespace EmailSender.EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(string toEmailAddress,string fromEmailAddress,string subject, string body);
    }
}