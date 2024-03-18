using Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPunchCard.Data.Models
{
    public class Punch
    {
        // Stämpel
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PunchId { get; set; }
        public DateTime PunchTimeRegistered { get; set; }
        [ForeignKey(nameof(UserPunchCards))]
        public int FK_UserPunchCard { get; set; }
        public virtual UserPunchCard UserPunchCards { get; set; }
    }
}
