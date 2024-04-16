using BlazorPunchCard.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorPunchCard.Data.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {

            // Seed Roles

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // -----------------------------------------------------------------------------


            // Seed Users

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                // important: don't forget NormalizedUserName, NormalizedEmail 
                new ApplicationUser {
                    Id = "1",
                    Name = "Malin Lindbom",
                    UserName = "malinlindbom@hotmail.com",
                    NormalizedUserName = "MALINLINDBOM@HOTMAIL.COM",
                    Email = "malinlindbom@hotmail.com",
                    NormalizedEmail = "MALINLINDBLOM@HOTMAIL.COM",
                    EmailConfirmed= true,
                    PhoneNumber = "0701234567"
                    },
                new ApplicationUser {
                    Id = "2",
                    Name = "Jon Westman",
                    UserName = "jonwestman@hotmail.com",
                    NormalizedUserName = "JONWESTMAN@HOTMAIL.COM",
                    Email = "jonwestman@hotmail.com",
                    NormalizedEmail = "JONWESTMAN@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0730625968"
                },
                new ApplicationUser {
                    Id = "3",
                    Name = "Andreas Blom",
                    UserName = "andreasblom@hotmail.com",
                    NormalizedUserName = "ANDREASBLOM@HOTMAIL.COM",
                    Email = "andreasblom@hotmail.com",
                    NormalizedEmail = "ANDREASBLOM@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0721234567"
                },
                new ApplicationUser {
                    Id = "4",
                    Name = "Erik Svensson",
                    UserName = "eriksvensson@hotmail.com",
                    NormalizedUserName = "ERIKSVENSSON@HOTMAIL.COM",
                    Email = "eriksvensson@hotmail.com",
                    NormalizedEmail = "ERIKSVENSSON@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0731234568"
                },
                new ApplicationUser {
                    Id = "5",
                    Name = "Sara Nordin",
                    UserName = "saranordin@hotmail.com",
                    NormalizedUserName = "SARANORDIN@HOTMAIL.COM",
                    Email = "saranordin@hotmail.com",
                    NormalizedEmail = "SARANORDIN@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0741234569"
                },
                new ApplicationUser {
                    Id = "6",
                    Name = "Lena Karlsson",
                    UserName = "lenakarlsson@hotmail.com",
                    NormalizedUserName = "LENAKARLSSON@HOTMAIL.COM",
                    Email = "lenakarlsson@hotmail.com",
                    NormalizedEmail = "LENAKARLSSON@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0751234570"
                },
                new ApplicationUser {
                    Id = "7",
                    Name = "Oscar Hedlund",
                    UserName = "oscarhedlund@hotmail.com",
                    NormalizedUserName = "OSCARHEDLUND@HOTMAIL.COM",
                    Email = "oscarhedlund@hotmail.com",
                    NormalizedEmail = "OSCARHEDLUND@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0761234571"
                },
                new ApplicationUser {
                    Id = "8",
                    Name = "Emma Johansson",
                    UserName = "emmajohansson@hotmail.com",
                    NormalizedUserName = "EMMAJOHANSSON@HOTMAIL.COM",
                    Email = "emmajohansson@hotmail.com",
                    NormalizedEmail = "EMMAJOHANSSON@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0771234572"
                },
                new ApplicationUser {
                    Id = "9",
                    Name = "Daniel Åberg",
                    UserName = "danielaberg@hotmail.com",
                    NormalizedUserName = "DANIELABERG@HOTMAIL.COM",
                    Email = "danielaberg@hotmail.com",
                    NormalizedEmail = "DANIELABERG@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0781234573"
                },
                new ApplicationUser {
                    Id = "10",
                    Name = "Linda Gustafsson",
                    UserName = "lindagustafsson@hotmail.com",
                    NormalizedUserName = "LINDAGUSTAFSSON@HOTMAIL.COM",
                    Email = "lindagustafsson@hotmail.com",
                    NormalizedEmail = "LINDAGUSTAFSSON@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0761234567"
                },
                new ApplicationUser {
                    Id = "11",
                    Name = "BokHörnan",
                    UserName = "bokhornan@hotmail.com",
                    NormalizedUserName = "BOKHORNAN@HOTMAIL.COM",
                    Email = "bokhornan@hotmail.com",
                    NormalizedEmail = "BOKHORNAN@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "12",
                    Name = "Din El",
                    UserName = "dinel@hotmail.com",
                    NormalizedUserName = "DINEL@HOTMAIL.COM",
                    Email = "dinel@hotmail.com",
                    NormalizedEmail = "DINEL@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "13",
                    Name = "Hemstädarna",
                    UserName = "hemstadarna@hotmail.com",
                    NormalizedUserName = "HEMSTADARNA@HOTMAIL.COM",
                    Email = "hemstadarna@hotmail.com",
                    NormalizedEmail = "HEMSTADARNA@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "14",
                    Name = "Cykelverkstan",
                    UserName = "cykelverkstan@hotmail.com",
                    NormalizedUserName = "CYKELVERKSTAN@HOTMAIL.COM",
                    Email = "cykelverkstan@hotmail.com",
                    NormalizedEmail = "CYKELVERKSTAN@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "15",
                    Name = "Klippoteket",
                    UserName = "klippoteket@hotmail.com",
                    NormalizedUserName = "KLIPPOTEKET@HOTMAIL.COM",
                    Email = "klippoteket@hotmail.com",
                    NormalizedEmail = "KLIPPOTEKET@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "16",
                    Name = "Blomsterplockarna",
                    UserName = "blomsterplockarna@hotmail.com",
                    NormalizedUserName = "BLOMSTERPLOCKARNA@HOTMAIL.COM",
                    Email = "blomsterplockarna@hotmail.com",
                    NormalizedEmail = "BLOMSTERPLOCKARNA@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "17",
                    Name = "Hantverksbageriet",
                    UserName = "hantverksbageriet@hotmail.com",
                    NormalizedUserName = "HANTVERKSBAKERIET@HOTMAIL.COM",
                    Email = "hantverksbageriet@hotmail.com",
                    NormalizedEmail = "HANTVERKSBAKERIET@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "18",
                    Name = "Guldkammen Frisör",
                    UserName = "guldkammenfrisor@hotmail.com",
                    NormalizedUserName = "GULDKAMMENFRISOR@HOTMAIL.COM",
                    Email = "guldkammenfrisor@hotmail.com",
                    NormalizedEmail = "GULDKAMMENFRISOR@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "19",
                    Name = "Fotvårdskliniken",
                    UserName = "fotvardskliniken@hotmail.com",
                    NormalizedUserName = "FOTVARDSKLINIKEN@HOTMAIL.COM",
                    Email = "fotvardskliniken@hotmail.com",
                    NormalizedEmail = "FOTVARDSKLINIKEN@HOTMAIL.COM",
                    EmailConfirmed = true
                },
                new ApplicationUser {
                    Id = "20",
                    Name = "TakSkottarna",
                    UserName = "takskottarna@hotmail.com",
                    NormalizedUserName = "TAKSKOTTARNA@HOTMAIL.COM",
                    Email = "takskottarna@hotmail.com",
                    NormalizedEmail = "TAKSKOTTARNA@HOTMAIL.COM",
                    EmailConfirmed = true
                }
            };


            builder.Entity<ApplicationUser>().HasData(users);

            ///----------------------------------------------------

            // Seed Companies

            List<Company> companies = new List<Company>()
            {
                    new Company { CompanyId=11, CompanyName="BokHörnan", Orgnr="456789", FK_ApplicationUserId="11"},
                    new Company { CompanyId=12, CompanyName="Din El", Orgnr="567890", FK_ApplicationUserId="12"},
                    new Company { CompanyId=13, CompanyName="Hemstädarna", Orgnr="678901", FK_ApplicationUserId="13"},
                    new Company { CompanyId=14, CompanyName="Cykelverkstan", Orgnr="789012", FK_ApplicationUserId="14"},
                    new Company { CompanyId=15, CompanyName="Klippoteket", Orgnr="890123", FK_ApplicationUserId="15"},
                    new Company { CompanyId=16, CompanyName="Blomsterplockarna", Orgnr="901234", FK_ApplicationUserId="16"},
                    new Company { CompanyId=17, CompanyName="Hantverksbageriet", Orgnr="012345", FK_ApplicationUserId="17"},
                    new Company { CompanyId=18, CompanyName="Guldkammen Frisör", Orgnr="1234567", FK_ApplicationUserId="18"},
                    new Company { CompanyId=19, CompanyName="Fotvårdskliniken", Orgnr="2345678", FK_ApplicationUserId="19"},
                    new Company { CompanyId=20, CompanyName="TakSkottarna", Orgnr="3456789", FK_ApplicationUserId="20"}
            };

            builder.Entity<Company>().HasData(companies);

            // -----------------------------------------------------------------------------

            // Seed PunchCards

            List<PunchCard> punchCards = new List<PunchCard>()
            {
                new PunchCard { PunchCardId = 1, PunchCardName = "BokKortet", Reward = "Få den 5:e boken gratis!", FK_CompanyId=11, PunchCardCount=5, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://bokhornan.se", LinkFacebook="http://facebook.com/bokhornan", LinkInstagram="http://instagram.com/bokhornan"},
                new PunchCard { PunchCardId = 2, PunchCardName = "ElKortet", Reward = "10% rabatt på nästa service", FK_CompanyId=12, PunchCardCount=3, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://dinel.se", LinkFacebook="http://facebook.com/dinel", LinkInstagram="http://instagram.com/dinel"},
                new PunchCard { PunchCardId = 3, PunchCardName = "StädKortet", Reward = "Var 10:e städning gratis", FK_CompanyId=13, PunchCardCount=10, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://hemstadarna.se", LinkFacebook="http://facebook.com/hemstadarna", LinkInstagram="http://instagram.com/hemstadarna"},
                new PunchCard { PunchCardId = 4, PunchCardName = "CykelKortet", Reward = "Gratis service efter 5 reparationer", FK_CompanyId=14, PunchCardCount=5, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://cykelverkstan.se", LinkFacebook="http://facebook.com/cykelverkstan", LinkInstagram="http://instagram.com/cykelverkstan"},
                new PunchCard { PunchCardId = 5, PunchCardName = "KlippKortet", Reward = "Var 6:e klippning gratis", FK_CompanyId=15, PunchCardCount=6, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://klippoteket.se", LinkFacebook="http://facebook.com/klippoteket", LinkInstagram="http://instagram.com/klippoteket"},
                new PunchCard { PunchCardId = 6, PunchCardName = "BlomKortet", Reward = "15% rabatt efter 5 köp", FK_CompanyId=16, PunchCardCount=5, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://blomsterplockarna.se", LinkFacebook="http://facebook.com/blomsterplockarna", LinkInstagram="http://instagram.com/blomsterplockarna"},
                new PunchCard { PunchCardId = 7, PunchCardName = "BageriKortet", Reward = "Köp 7 bröd, få det 8:e gratis", FK_CompanyId=17, PunchCardCount=8, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://hantverksbageriet.se", LinkFacebook="http://facebook.com/hantverksbageriet", LinkInstagram="http://instagram.com/hantverksbageriet"},
                new PunchCard { PunchCardId = 8, PunchCardName = "FrisörKortet", Reward = "20% rabatt på färgning efter 5 besök", FK_CompanyId=18, PunchCardCount=5, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://guldkammenfrisor.se", LinkFacebook="http://facebook.com/guldkammenfrisor", LinkInstagram="http://instagram.com/guldkammenfrisor"},
                new PunchCard { PunchCardId = 9, PunchCardName = "FotvårdKortet", Reward = "En gratis fotmassage efter 4 behandlingar", FK_CompanyId=19, PunchCardCount=4, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://fotvardskliniken.se", LinkFacebook="http://facebook.com/fotvardskliniken", LinkInstagram="http://instagram.com/fotvardskliniken"},
                new PunchCard { PunchCardId = 10, PunchCardName = "SnöKortet", Reward = "Gratis takskottning efter varje 5:e tillfälle", FK_CompanyId=20, PunchCardCount=5, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://takskottarna.se", LinkFacebook="http://facebook.com/takskottarna", LinkInstagram="http://instagram.com/takskottarna"},
				new PunchCard { PunchCardId = 13, PunchCardName = "BrödPlusKortet", Reward = "Dubbla stämplar på tisdagar", FK_CompanyId=17, PunchCardCount=10, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://hantverksbageriet.se", LinkFacebook="http://facebook.com/hantverksbageriet", LinkInstagram="http://instagram.com/hantverksbageriet"},
                new PunchCard { PunchCardId = 14, PunchCardName = "StylingKortet", Reward = "Gratis stylingprodukt efter 3 klippningar", FK_CompanyId=18, PunchCardCount=3, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://guldkammenfrisor.se", LinkFacebook="http://facebook.com/guldkammenfrisor", LinkInstagram="http://instagram.com/guldkammenfrisor"},
                new PunchCard { PunchCardId = 15, PunchCardName = "VårdFörFötternaKortet", Reward = "10% rabatt på nästa köp av fotvårdsprodukter", FK_CompanyId=19, PunchCardCount=1, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://fotvardskliniken.se", LinkFacebook="http://facebook.com/fotvardskliniken", LinkInstagram="http://instagram.com/fotvardskliniken"},
                new PunchCard { PunchCardId = 16, PunchCardName = "IsbrytarenKortet", Reward = "20% rabatt på snöröjningstjänster efter 10 köp", FK_CompanyId=20, PunchCardCount=10, DurationStart = new DateOnly(2024,1,1), DurationEnd = new DateOnly(2025,1,1), LinkWebsite="http://takskottarna.se", LinkFacebook="http://facebook.com/takskottarna", LinkInstagram="http://instagram.com/takskottarna"}
			};


            builder.Entity<PunchCard>().HasData(punchCards);

			// -----------------------------------------------------------------------------

			// Seed UserPunchCard

			List<UserPunchCard> userPunchCard = new List<UserPunchCard>()
			{
				new UserPunchCard {UserPunchCardId = 1, FK_ApplicationUserId = "1", IsActive = true, FK_PunchCardId = 1 },
				new UserPunchCard {UserPunchCardId = 2, FK_ApplicationUserId = "1", IsActive = true, FK_PunchCardId = 1 },
				new UserPunchCard {UserPunchCardId = 3, FK_ApplicationUserId = "1", IsActive = false, FK_PunchCardId = 1 }
			};

			builder.Entity<UserPunchCard>().HasData(userPunchCard);

			// -----------------------------------------------------------------------------

			// Seed Punches

			List<Punch> punches = new List<Punch>()
			{
				new Punch {PunchId = 1, FK_UserPunchCard = 1, PunchTimeRegistered = DateTime.Now }
			};

			builder.Entity<Punch>().HasData(punches);

			// -----------------------------------------------------------------------------

			// Seed Punches

			List<Reward> rewards = new List<Reward>()
			{
				new Reward {RewardId = 1, IsActive = true, FK_UserPunchCardId = 1, RedemptionCode = 123456, TimeRegistered = DateTime.Now, TypeOfReward = "One free book"},
				new Reward {RewardId = 2, IsActive = false, FK_UserPunchCardId = 1, RedemptionCode = 234567, TimeRegistered = DateTime.Now, TypeOfReward = "Two free books"}
			};

			builder.Entity<Reward>().HasData(rewards);

			// -----------------------------------------------------------------------------

			// Seed UserRoles


			List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            // Add Password For All Users

            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "H3jsan!");
            }

            // Adding role user to the first 10 users
            for (int i = 0; i <= 10; i++)
            {
                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = users[i].Id,
                    RoleId =
                    roles.First(q => q.Name == "User").Id
                });
            }

            // Adding role admin to the last 10 users
            for (int i = 11; i < users.Count; i++)
            {
                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = users[i].Id,
                    RoleId =
                    roles.First(q => q.Name == "Admin").Id
                });
            }

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
