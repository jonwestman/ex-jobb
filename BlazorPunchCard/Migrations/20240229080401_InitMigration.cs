using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorPunchCard.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipLevels",
                columns: table => new
                {
                    MembershipLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipLevels", x => x.MembershipLevelId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileStorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_AspNetUsers_FK_ApplicationUserId",
                        column: x => x.FK_ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Orgnr = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FK_MemberShipLevelId = table.Column<int>(type: "int", nullable: true),
                    FK_ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_AspNetUsers_FK_ApplicationUserId",
                        column: x => x.FK_ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_MembershipLevels_FK_MemberShipLevelId",
                        column: x => x.FK_MemberShipLevelId,
                        principalTable: "MembershipLevels",
                        principalColumn: "MembershipLevelId");
                });

            migrationBuilder.CreateTable(
                name: "PunchCards",
                columns: table => new
                {
                    PunchCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PunchCardName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PunchCardCount = table.Column<int>(type: "int", nullable: false),
                    DurationStart = table.Column<DateOnly>(type: "date", nullable: false),
                    DurationEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    LinkWebsite = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    LinkInstagram = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    LinkFacebook = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    FK_CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunchCards", x => x.PunchCardId);
                    table.ForeignKey(
                        name: "FK_PunchCards_Companies_FK_CompanyId",
                        column: x => x.FK_CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPunchCards",
                columns: table => new
                {
                    UserPunchCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FK_ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FK_PunchCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPunchCards", x => x.UserPunchCardId);
                    table.ForeignKey(
                        name: "FK_UserPunchCards_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPunchCards_PunchCards_FK_PunchCardId",
                        column: x => x.FK_PunchCardId,
                        principalTable: "PunchCards",
                        principalColumn: "PunchCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punches",
                columns: table => new
                {
                    PunchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PunchTimeRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_UserPunchCard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punches", x => x.PunchId);
                    table.ForeignKey(
                        name: "FK_Punches_UserPunchCards_FK_UserPunchCard",
                        column: x => x.FK_UserPunchCard,
                        principalTable: "UserPunchCards",
                        principalColumn: "UserPunchCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    RewardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfReward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedemptionCode = table.Column<int>(type: "int", nullable: false),
                    TimeRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FK_UserPunchCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.RewardId);
                    table.ForeignKey(
                        name: "FK_Rewards_UserPunchCards_FK_UserPunchCardId",
                        column: x => x.FK_UserPunchCardId,
                        principalTable: "UserPunchCards",
                        principalColumn: "UserPunchCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", null, "Admin", "ADMIN" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "4d7eaad7-4b78-4e65-8765-076e403b57e4", null, "malinlindbom@hotmail.com", true, false, null, "Malin Lindbom", "MALINLINDBLOM@HOTMAIL.COM", "MALINLINDBOM@HOTMAIL.COM", "AQAAAAIAAYagAAAAELcOzLhv72Qw/tjgrM6rp16qa+QC6duYJ/9wyY9xgk2WZskHW9eoUNQvDPHkSVv5OQ==", "0701234567", false, "c4f71a9a-f8bd-4606-a8c6-d22b8a6cc32c", false, "malinlindbom@hotmail.com" },
                    { "10", 0, "c09b9516-fc9b-47a2-9731-92a650dc19ce", null, "lindagustafsson@hotmail.com", true, false, null, "Linda Gustafsson", "LINDAGUSTAFSSON@HOTMAIL.COM", "LINDAGUSTAFSSON@HOTMAIL.COM", "AQAAAAIAAYagAAAAEEodk8P7UxJPTnE6OhCe79wmot9R5Ynrnt1p/93HbrRdv4I8V7VEfeJZixW20UfP6A==", "0761234567", false, "0b91d332-f77f-4a58-ac52-2de1acd55309", false, "lindagustafsson@hotmail.com" },
                    { "11", 0, "e2b43ad7-f0e3-4c6c-a040-b5b453f65f34", null, "bokhornan@hotmail.com", true, false, null, "BokHörnan", "BOKHORNAN@HOTMAIL.COM", "BOKHORNAN@HOTMAIL.COM", "AQAAAAIAAYagAAAAEIpRW5uWEzK2x8NyESgvQttOG8jnvGQXEW36VLPvsuXziDRWz7PsNkKrVVxdM17Ghg==", null, false, "edc06325-be4e-4612-8f3d-15c1de0c77da", false, "bokhornan@hotmail.com" },
                    { "12", 0, "16d6cdc7-1fd9-48b4-b5ff-5b5f73d2deea", null, "dinel@hotmail.com", true, false, null, "Din El", "DINEL@HOTMAIL.COM", "DINEL@HOTMAIL.COM", "AQAAAAIAAYagAAAAEL/+oN2zKN56KunnpYk9k15xgsSwBQnJ55iTKV21mALKZk4/A+9b6Bfk6D85iDVoCw==", null, false, "fa2337b7-acf3-4471-8436-348aa01ff7eb", false, "dinel@hotmail.com" },
                    { "13", 0, "8b75f4a7-fe8f-4b07-9c9b-580abc147854", null, "hemstadarna@hotmail.com", true, false, null, "Hemstädarna", "HEMSTADARNA@HOTMAIL.COM", "HEMSTADARNA@HOTMAIL.COM", "AQAAAAIAAYagAAAAEMuk+A/yJLSb2j3XduTZ1cC2hgsn3oTRxX3bSS0OWL9NsnbDm/IP4R7/P8OMKVTNjw==", null, false, "ad7d840c-87e8-4105-b66e-07e525c7416f", false, "hemstadarna@hotmail.com" },
                    { "14", 0, "8075bf13-fc19-4bb5-bf57-ee00bb165f48", null, "cykelverkstan@hotmail.com", true, false, null, "Cykelverkstan", "CYKELVERKSTAN@HOTMAIL.COM", "CYKELVERKSTAN@HOTMAIL.COM", "AQAAAAIAAYagAAAAEEeZQLd44w1rBkxocRUyjsJkc55vqfoopBNOGopxITkEE74eAm5ty/WNWuHneez3bA==", null, false, "3fe00155-c385-4a75-bd18-e9b83b52e77b", false, "cykelverkstan@hotmail.com" },
                    { "15", 0, "af08f071-1bf2-4f0f-aa05-5039c9938a4f", null, "klippoteket@hotmail.com", true, false, null, "Klippoteket", "KLIPPOTEKET@HOTMAIL.COM", "KLIPPOTEKET@HOTMAIL.COM", "AQAAAAIAAYagAAAAEEfYJRjzk/4KPk4aoBpOsmz0trkTMr/xWchnfufuDEKpU0m9W/Vo/6fduRHhjYJtEw==", null, false, "d1e5e214-c003-4a9f-acb0-ff30ccce58bb", false, "klippoteket@hotmail.com" },
                    { "16", 0, "d432dba2-0a67-4c16-bcf1-ac1cf837c623", null, "blomsterplockarna@hotmail.com", true, false, null, "Blomsterplockarna", "BLOMSTERPLOCKARNA@HOTMAIL.COM", "BLOMSTERPLOCKARNA@HOTMAIL.COM", "AQAAAAIAAYagAAAAEAxyuKe6oJSxkZiMf1fvANo5hxik0rUkAo7MRn1l6JASD+J75KXJ/ggZeD4PpX5CKw==", null, false, "6ff75d66-9af1-40b9-b173-2f8a8aae8c4f", false, "blomsterplockarna@hotmail.com" },
                    { "17", 0, "91276c2f-147c-4a6e-bd25-6fc0cbbaef15", null, "hantverksbageriet@hotmail.com", true, false, null, "Hantverksbageriet", "HANTVERKSBAKERIET@HOTMAIL.COM", "HANTVERKSBAKERIET@HOTMAIL.COM", "AQAAAAIAAYagAAAAEAA9Zz1gGRcY2ajJxhhdJziDWexMnVZTZ/DxbcYgMfYQVans0GH3pE8VwFW/M2I4ow==", null, false, "a6ec2161-5a71-4b23-9fc7-bc7307f0f300", false, "hantverksbageriet@hotmail.com" },
                    { "18", 0, "08d313f9-e4aa-4d1a-9345-0f6ca30dbe67", null, "guldkammenfrisor@hotmail.com", true, false, null, "Guldkammen Frisör", "GULDKAMMENFRISOR@HOTMAIL.COM", "GULDKAMMENFRISOR@HOTMAIL.COM", "AQAAAAIAAYagAAAAEK5raWVGtaBiHlGoy/oquZCXXAxhAm2vlPwH3YciDR22muTTH1cHbN6iIeeend7Vbg==", null, false, "c8c7183b-b73b-411b-8aab-95966925a61c", false, "guldkammenfrisor@hotmail.com" },
                    { "19", 0, "f8dd7cc9-01b1-4269-a4b0-c0a3e9300ad6", null, "fotvardskliniken@hotmail.com", true, false, null, "Fotvårdskliniken", "FOTVARDSKLINIKEN@HOTMAIL.COM", "FOTVARDSKLINIKEN@HOTMAIL.COM", "AQAAAAIAAYagAAAAEHB5HQRzISrjO51HYm4+nMoHiHie2vO9SxGzrQGAewA985VzotW6gE7Mz7/sKFW9nw==", null, false, "ae38b5ef-2820-410e-8b55-5dc64ae6e11c", false, "fotvardskliniken@hotmail.com" },
                    { "2", 0, "bbeefb5e-c839-47a0-b4b5-46392e4e9dd9", null, "jonwestman@hotmail.com", true, false, null, "Jon Westman", "JONWESTMAN@HOTMAIL.COM", "JONWESTMAN@HOTMAIL.COM", "AQAAAAIAAYagAAAAEDKgoy7Z9yfJYuK8KLNI9ngGiIPNPFdFxGJrsyDK01GlVwoJ6LOzmGS5ZPOyv6hkow==", "0730625968", false, "e7b1fc51-ab52-4735-8e89-66e178508998", false, "jonwestman@hotmail.com" },
                    { "20", 0, "af38e6a3-7c62-4229-a415-d70e2ef81c56", null, "takskottarna@hotmail.com", true, false, null, "TakSkottarna", "TAKSKOTTARNA@HOTMAIL.COM", "TAKSKOTTARNA@HOTMAIL.COM", "AQAAAAIAAYagAAAAEMmFSAK6EntSjqawf2gVpPMOnaDZcVlQHth3zWpjJSRVG41Pm79IaL5VKR+gW1V2cg==", null, false, "f872aed7-1f76-4ffa-ba29-e45406b080e5", false, "takskottarna@hotmail.com" },
                    { "3", 0, "2134b99b-18a2-4e65-baa2-e7d84aede8de", null, "andreasblom@hotmail.com", true, false, null, "Andreas Blom", "ANDREASBLOM@HOTMAIL.COM", "ANDREASBLOM@HOTMAIL.COM", "AQAAAAIAAYagAAAAEN3u+oOWCELyOkbeX4BgIblHzb51UllOPjHu6/uoybqdaYM8f7xC/FXhDAoP6N5bRw==", "0721234567", false, "5d3a615c-7be8-485e-bfb6-c53cdcf6db5f", false, "andreasblom@hotmail.com" },
                    { "4", 0, "87d09f4f-8cef-4dbc-8990-724ba6d9b18f", null, "eriksvensson@hotmail.com", true, false, null, "Erik Svensson", "ERIKSVENSSON@HOTMAIL.COM", "ERIKSVENSSON@HOTMAIL.COM", "AQAAAAIAAYagAAAAEM/vVrWxwHdgQeXM3jdgsqwaG75V9AcxioqyQAMvWFL3SArSDQxxJTUho3shW0rq8A==", "0731234568", false, "8129399b-92a8-4a61-869c-3f686726bb34", false, "eriksvensson@hotmail.com" },
                    { "5", 0, "abac0096-d2b2-49e9-9976-f5aded581592", null, "saranordin@hotmail.com", true, false, null, "Sara Nordin", "SARANORDIN@HOTMAIL.COM", "SARANORDIN@HOTMAIL.COM", "AQAAAAIAAYagAAAAEPeZMR6a7DO+YY+9mcwoM21yXrrQFDPqLKZf2rDdp8VZPsfsWElqSs3fZ4fo2atF2w==", "0741234569", false, "9d15ca39-4061-419a-b32d-6f6ab347c5c1", false, "saranordin@hotmail.com" },
                    { "6", 0, "b896f7c1-e692-49c4-87b3-b9a54568d5d0", null, "lenakarlsson@hotmail.com", true, false, null, "Lena Karlsson", "LENAKARLSSON@HOTMAIL.COM", "LENAKARLSSON@HOTMAIL.COM", "AQAAAAIAAYagAAAAECzgwT888dU9RsCIhy57JONkOOZ7WO8UNOuWttcLDbaZOjnAn0YhcbmZWSPeGAUeKg==", "0751234570", false, "fde28768-931b-4dd2-9b31-a2fea282b4ea", false, "lenakarlsson@hotmail.com" },
                    { "7", 0, "66ecf04d-377a-4f81-9118-c866e46e3662", null, "oscarhedlund@hotmail.com", true, false, null, "Oscar Hedlund", "OSCARHEDLUND@HOTMAIL.COM", "OSCARHEDLUND@HOTMAIL.COM", "AQAAAAIAAYagAAAAELEMS055XDOe3uxycp92PCo+JiyJaDl/dGrQs7KAEKEV4r0b0EtQISgSsIU8YlnYPw==", "0761234571", false, "9797bd83-a8cd-4b03-ac40-3c3017fc7dc1", false, "oscarhedlund@hotmail.com" },
                    { "8", 0, "87985b17-0fe8-49bf-a7b4-9eeea524c480", null, "emmajohansson@hotmail.com", true, false, null, "Emma Johansson", "EMMAJOHANSSON@HOTMAIL.COM", "EMMAJOHANSSON@HOTMAIL.COM", "AQAAAAIAAYagAAAAEAs3NlbqpdX5NTqBVJRSi6BbooFjJ9H45z09eyWHQHn4sRecYqiOlxO9NmREFayS7w==", "0771234572", false, "7df0b7c6-0382-4632-936a-3a2b33b878df", false, "emmajohansson@hotmail.com" },
                    { "9", 0, "fafcd08e-253d-4e7e-95bf-61a971ce99f4", null, "danielaberg@hotmail.com", true, false, null, "Daniel Åberg", "DANIELABERG@HOTMAIL.COM", "DANIELABERG@HOTMAIL.COM", "AQAAAAIAAYagAAAAEJDyB20pUwynYsOEkWF7u2vzKIC04Dc1BtPjttTGEkYK/v5l94pF7FlanRGvRegsDg==", "0781234573", false, "43c1f906-6df6-47aa-a976-79871adbf8c1", false, "danielaberg@hotmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "1" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "10" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "11" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "12" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "13" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "14" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "15" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "16" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "17" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "18" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "19" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "2" },
                    { "735047f0-0f2a-4b95-8c5a-8a354dde27fa", "20" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "3" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "4" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "5" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "6" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "7" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "8" },
                    { "e921999a-7655-4c81-ad2e-18258c30d747", "9" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "CompanyName", "FK_ApplicationUserId", "FK_MemberShipLevelId", "Orgnr" },
                values: new object[,]
                {
                    { 11, "BokHörnan", "11", null, "456789" },
                    { 12, "Din El", "12", null, "567890" },
                    { 13, "Hemstädarna", "13", null, "678901" },
                    { 14, "Cykelverkstan", "14", null, "789012" },
                    { 15, "Klippoteket", "15", null, "890123" },
                    { 16, "Blomsterplockarna", "16", null, "901234" },
                    { 17, "Hantverksbageriet", "17", null, "012345" },
                    { 18, "Guldkammen Frisör", "18", null, "1234567" },
                    { 19, "Fotvårdskliniken", "19", null, "2345678" },
                    { 20, "TakSkottarna", "20", null, "3456789" }
                });

            migrationBuilder.InsertData(
                table: "PunchCards",
                columns: new[] { "PunchCardId", "DurationEnd", "DurationStart", "FK_CompanyId", "LinkFacebook", "LinkInstagram", "LinkWebsite", "PunchCardCount", "PunchCardName", "Reward" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 11, "http://facebook.com/bokhornan", "http://instagram.com/bokhornan", "http://bokhornan.se", 5, "BokKortet", "Få den 5:e boken gratis!" },
                    { 2, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 12, "http://facebook.com/dinel", "http://instagram.com/dinel", "http://dinel.se", 3, "ElKortet", "10% rabatt på nästa service" },
                    { 3, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 13, "http://facebook.com/hemstadarna", "http://instagram.com/hemstadarna", "http://hemstadarna.se", 10, "StädKortet", "Var 10:e städning gratis" },
                    { 4, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 14, "http://facebook.com/cykelverkstan", "http://instagram.com/cykelverkstan", "http://cykelverkstan.se", 5, "CykelKortet", "Gratis service efter 5 reparationer" },
                    { 5, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 15, "http://facebook.com/klippoteket", "http://instagram.com/klippoteket", "http://klippoteket.se", 6, "KlippKortet", "Var 6:e klippning gratis" },
                    { 6, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 16, "http://facebook.com/blomsterplockarna", "http://instagram.com/blomsterplockarna", "http://blomsterplockarna.se", 5, "BlomKortet", "15% rabatt efter 5 köp" },
                    { 7, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 17, "http://facebook.com/hantverksbageriet", "http://instagram.com/hantverksbageriet", "http://hantverksbageriet.se", 8, "BageriKortet", "Köp 7 bröd, få det 8:e gratis" },
                    { 8, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 18, "http://facebook.com/guldkammenfrisor", "http://instagram.com/guldkammenfrisor", "http://guldkammenfrisor.se", 5, "FrisörKortet", "20% rabatt på färgning efter 5 besök" },
                    { 9, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 19, "http://facebook.com/fotvardskliniken", "http://instagram.com/fotvardskliniken", "http://fotvardskliniken.se", 4, "FotvårdKortet", "En gratis fotmassage efter 4 behandlingar" },
                    { 10, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 20, "http://facebook.com/takskottarna", "http://instagram.com/takskottarna", "http://takskottarna.se", 5, "SnöKortet", "Gratis takskottning efter varje 5:e tillfälle" },
                    { 13, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 17, "http://facebook.com/hantverksbageriet", "http://instagram.com/hantverksbageriet", "http://hantverksbageriet.se", 10, "BrödPlusKortet", "Dubbla stämplar på tisdagar" },
                    { 14, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 18, "http://facebook.com/guldkammenfrisor", "http://instagram.com/guldkammenfrisor", "http://guldkammenfrisor.se", 3, "StylingKortet", "Gratis stylingprodukt efter 3 klippningar" },
                    { 15, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 19, "http://facebook.com/fotvardskliniken", "http://instagram.com/fotvardskliniken", "http://fotvardskliniken.se", 1, "VårdFörFötternaKortet", "10% rabatt på nästa köp av fotvårdsprodukter" },
                    { 16, new DateOnly(2025, 1, 1), new DateOnly(2024, 1, 1), 20, "http://facebook.com/takskottarna", "http://instagram.com/takskottarna", "http://takskottarna.se", 10, "IsbrytarenKortet", "20% rabatt på snöröjningstjänster efter 10 köp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FK_ApplicationUserId",
                table: "Companies",
                column: "FK_ApplicationUserId",
                unique: true,
                filter: "[FK_ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FK_MemberShipLevelId",
                table: "Companies",
                column: "FK_MemberShipLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_FK_ApplicationUserId",
                table: "Pictures",
                column: "FK_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PunchCards_FK_CompanyId",
                table: "PunchCards",
                column: "FK_CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Punches_FK_UserPunchCard",
                table: "Punches",
                column: "FK_UserPunchCard");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_FK_UserPunchCardId",
                table: "Rewards",
                column: "FK_UserPunchCardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPunchCards_ApplicationUsersId",
                table: "UserPunchCards",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPunchCards_FK_PunchCardId",
                table: "UserPunchCards",
                column: "FK_PunchCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Punches");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserPunchCards");

            migrationBuilder.DropTable(
                name: "PunchCards");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MembershipLevels");
        }
    }
}
