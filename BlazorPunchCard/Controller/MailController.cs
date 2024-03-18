using BlazorPunchCard.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BlazorPunchCard.Controller
{
    public class MailController
    {
        private readonly IEmailSender _emailSender;

        public MailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) 
        {
            await _emailSender.SendEmailAsync(email, "Bekräfta mail", $"Var vänlig bekräfta ditt konto genom <a href='{confirmationLink}'>att klicka här</a>.");
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            await _emailSender.SendEmailAsync(email, "Återställ ditt lösenord", $"Var vänlig återställ ditt lösenord genom att <a href='{resetLink}'>klicka här</a>.");
        }

        public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        { 
            await _emailSender.SendEmailAsync(email, "Återställ ditt lösenord", $"Var vänlig återställ ditt lösenord genom att <a href='{resetCode}'>klicka här</a>.");
        }
    }
}
