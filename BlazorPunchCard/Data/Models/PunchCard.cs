using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class PunchCard
    {
        // Stämpelkortsmall/template
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PunchCardId { get; set; }
        [Required]
        [StringLength(40)]
        public string PunchCardName { get; set; }
        [StringLength(120)]
        public required string Reward { get; set; }

        public int PunchCardCount { get; set; }

        public DateOnly DurationStart { get; set; }
        public DateOnly DurationEnd { get; set; }

        [StringLength(120)]
        public string? LinkWebsite { get; set; }
        [StringLength(120)]
        public string? LinkInstagram { get; set; }
        [StringLength(120)]
        public string? LinkFacebook { get; set; }

        [ForeignKey(nameof(Companies))]
        public int FK_CompanyId { get; set; }
        public Company Companies { get; set; }
        public virtual ICollection<UserPunchCard> UserPunchCards { get; set; }
    }
}
