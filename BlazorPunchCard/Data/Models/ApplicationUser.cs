using BlazorPunchCard.Data.Models;
using Microsoft.AspNetCore.Identity;
using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace BlazorPunchCard.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateOnly? DateOfBirth { get; set; }
        
        public virtual Company? Company { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }       

        public virtual ICollection<UserPunchCard> UserPunchCards { get; set; }
        public virtual ICollection<Picture?> Pictures { get; set; }
    }
}
