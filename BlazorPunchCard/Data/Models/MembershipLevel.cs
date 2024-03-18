using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class MembershipLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MembershipLevelId { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; } // Gold, Silver or Bronze maybe?

        public virtual ICollection<Company>? Companies { get; set; }
    }
}
