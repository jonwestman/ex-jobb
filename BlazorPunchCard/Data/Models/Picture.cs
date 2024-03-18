using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPunchCard.Data.Models
{
    public class Picture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureId { get; set; }
        public string? FileName { get; set; }
        public string? FileStorageUrl { get; set; }
        public string? ContentType { get; set; }

        [ForeignKey(nameof(ApplicationUsers))]
        public string FK_ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
    }
}
