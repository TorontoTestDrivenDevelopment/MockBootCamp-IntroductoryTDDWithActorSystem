namespace EmailSender.Tests
{
    public class EmailSender : IEmailSender
    {
        public static bool EmailHasBeenSent { set; get; }

        public void SendEmail(string fromEmailAddress)
        {
            EmailHasBeenSent = true;
        }
    }
}