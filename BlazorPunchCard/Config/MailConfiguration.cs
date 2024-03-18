namespace BlazorPunchCard.Config
{
    public class MailConfiguration
    {
        public const string NodeMailer = "NodeMailer";
        public required string Host { get; set; }
        public required int Port { get; set; }
        public required Auth Authorization { get; set; }
        public class Auth 
        {
            public required string User { get; set; }
            public required string Password { get; set; }
        }
    }
}
