using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPunchCard.Data.Models
{
    public class Reward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RewardId { get; set; }
        public required string TypeOfReward { get; set; }
        public required int RedemptionCode { get; set; }
        public required DateTime TimeRegistered { get; set; }
        public bool IsActive { get; set; } = false;
        [ForeignKey(nameof(UserPunchCards))]
        public int FK_UserPunchCardId { get; set; }
        public virtual UserPunchCard UserPunchCards { get; set; }    
    }
}
