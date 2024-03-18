namespace BlazorPunchCard.Data.Models.ViewModels
{
    public class DashBoardViewModel
    {
        public string CustomerPhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string? NumberOfPunches { get; set; }
        public int? NumberOfRewards { get; set; }
        public int? NumberOfRewardsRedeeemed { get; set; }
        public string? NameOfPunchCard { get; set; }
        public string TransactionType { get; set; }
    }
}
