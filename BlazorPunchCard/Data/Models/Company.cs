using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(50)]
        public required string CompanyName { get; set; }
        [Required]
        [StringLength(30)]
        public required string Orgnr { get; set; }

        [ForeignKey(nameof(MemberShipLevels))]
        public int? FK_MemberShipLevelId { get; set; }
        public MembershipLevel? MemberShipLevels { get; set; }

        [ForeignKey(nameof(ApplicationUsers))]
        public string? FK_ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; }
        public virtual ICollection<PunchCard>? PunchCards { get; set; }
    }
}
