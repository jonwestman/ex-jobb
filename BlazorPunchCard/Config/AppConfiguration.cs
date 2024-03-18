namespace BlazorPunchCard.Config
{
    public class AppConfiguration
    {
        public const string ConnectionStrings = "ConnectionStrings";
        public required string DefaultConnection { get; set; }
        public required string Storage { get; set; }
    }
}
