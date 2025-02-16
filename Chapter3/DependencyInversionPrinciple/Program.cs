namespace DependencyInversionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Email
    {
        public void SendEmail()
        {
            Console.WriteLine("Email sent");
        }
    }

    public class Notification
    {
        private readonly Email _email;
        public Notification()
        {
            _email = new Email();
        }
        public void SendNotification()
        {
            _email.SendEmail();
        }
    }
}
