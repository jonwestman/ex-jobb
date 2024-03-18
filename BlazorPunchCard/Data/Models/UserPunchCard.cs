using Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPunchCard.Data.Models
{
    public class UserPunchCard
    {
        //Stämpelkort/PunchCard
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserPunchCardId { get; set; }
        public bool IsActive { get; set; } = false;   

        [ForeignKey(nameof(ApplicationUser))]
        public string? FK_ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; }

        [ForeignKey(nameof(PunchCards))]
        public int FK_PunchCardId { get; set; }
        public PunchCard PunchCards { get; set; }
        public virtual ICollection<Punch> Punches { get; set; }
    }
}
