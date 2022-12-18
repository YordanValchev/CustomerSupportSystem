using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerSupportSystem.Infrastructure.Migrations
{
    public partial class InfrastructureSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsoAlfa2Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IsoAlfa3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IsoNumericCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobTitleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_JobTitles",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JobTitleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Contacts",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Employees",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConsultantId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionContractNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsSubscriptionActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Consultants",
                        column: x => x.ConsultantId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partners_Countries",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Contacts",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Employees",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartnerContacts",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerContacts", x => new { x.PartnerId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_PartnerContacts_Contacts",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartnerContacts_Partners",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DeteFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Partners",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Priorities",
                        column: x => x.PriorityId,
                        principalTable: "TicketPriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Statuses",
                        column: x => x.StatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Types",
                        column: x => x.TypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketFiles_Tickets",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketParticipants",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketParticipants", x => new { x.TicketId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TicketParticipants_Tickets",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketParticipants_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PostingText = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    WorkedTime = table.Column<int>(type: "int", nullable: true),
                    IsTimeBillable = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPosts_Statuses",
                        column: x => x.StatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketPosts_Tickets",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketPosts_Users",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "361c7033-86bb-42e0-a264-3f560e1da74d", "e43e77f0-405c-4b87-b845-82a0106341d8", "Support", "SUPPORT" },
                    { "5b35eb07-6f63-41eb-8a44-5178055f3019", "559fa7e0-d92b-42fa-95c2-560501bfb78d", "Client", "CLIENT" },
                    { "c838fb22-a99a-42d7-9c00-9bae1b092cfd", "6271cd86-26b1-47ee-8663-aa4693b1cd66", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c80cb755-6247-4474-aa26-43a41d78691a", 0, "ffcc9392-0dad-42ee-bdd8-a4d21db5938f", "admin@admin.com", false, true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEA3UsjTGr1v7dQNoKVcaFtQkmHcdGvxffFrIcQF14uIa5/Iu18QEsd67I0RuWT1MBQ==", null, false, "ff2457a3-128f-433a-a4b9-e0afe3f97374", false, "admin" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoAlfa2Code", "IsoAlfa3Code", "IsoNumericCode", "Name" },
                values: new object[,]
                {
                    { 1, "AF", "AFG", 4, "Afghanistan" },
                    { 2, "AL", "ALB", 8, "Albania" },
                    { 3, "AQ", "ATA", 10, "Antarctica" },
                    { 4, "DZ", "DZA", 12, "Algeria" },
                    { 5, "AS", "ASM", 16, "American Samoa" },
                    { 6, "AD", "AND", 20, "Andorra" },
                    { 7, "AO", "AGO", 24, "Angola" },
                    { 8, "AG", "ATG", 28, "Antigua and Barbuda" },
                    { 9, "AZ", "AZE", 31, "Azerbaijan" },
                    { 10, "AR", "ARG", 32, "Argentina" },
                    { 11, "AU", "AUS", 36, "Australia" },
                    { 12, "AT", "AUT", 40, "Austria" },
                    { 13, "BS", "BHS", 44, "Bahamas (the)" },
                    { 14, "BH", "BHR", 48, "Bahrain" },
                    { 15, "BD", "BGD", 50, "Bangladesh" },
                    { 16, "AM", "ARM", 51, "Armenia" },
                    { 17, "BB", "BRB", 52, "Barbados" },
                    { 18, "BE", "BEL", 56, "Belgium" },
                    { 19, "BM", "BMU", 60, "Bermuda" },
                    { 20, "BT", "BTN", 64, "Bhutan" },
                    { 21, "BO", "BOL", 68, "Bolivia (Plurinational State of)" },
                    { 22, "BA", "BIH", 70, "Bosnia and Herzegovina" },
                    { 23, "BW", "BWA", 72, "Botswana" },
                    { 24, "BV", "BVT", 74, "Bouvet Island" },
                    { 25, "BR", "BRA", 76, "Brazil" },
                    { 26, "BZ", "BLZ", 84, "Belize" },
                    { 27, "IO", "IOT", 86, "British Indian Ocean Territory (the)" },
                    { 28, "SB", "SLB", 90, "Solomon Islands" },
                    { 29, "VG", "VGB", 92, "Virgin Islands (British)" },
                    { 30, "BN", "BRN", 96, "Brunei Darussalam" },
                    { 31, "BG", "BGR", 100, "Bulgaria" },
                    { 32, "MM", "MMR", 104, "Myanmar" },
                    { 33, "BI", "BDI", 108, "Burundi" },
                    { 34, "BY", "BLR", 112, "Belarus" },
                    { 35, "KH", "KHM", 116, "Cambodia" },
                    { 36, "CM", "CMR", 120, "Cameroon" },
                    { 37, "CA", "CAN", 124, "Canada" },
                    { 38, "CV", "CPV", 132, "Cabo Verde" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoAlfa2Code", "IsoAlfa3Code", "IsoNumericCode", "Name" },
                values: new object[,]
                {
                    { 39, "KY", "CYM", 136, "Cayman Islands (the)" },
                    { 40, "CF", "CAF", 140, "Central African Republic (the)" },
                    { 41, "LK", "LKA", 144, "Sri Lanka" },
                    { 42, "TD", "TCD", 148, "Chad" },
                    { 43, "CL", "CHL", 152, "Chile" },
                    { 44, "CN", "CHN", 156, "China" },
                    { 45, "TW", "TWN", 158, "Taiwan (Province of China)" },
                    { 46, "CX", "CXR", 162, "Christmas Island" },
                    { 47, "CC", "CCK", 166, "Cocos (Keeling) Islands (the)" },
                    { 48, "CO", "COL", 170, "Colombia" },
                    { 49, "KM", "COM", 174, "Comoros (the)" },
                    { 50, "YT", "MYT", 175, "Mayotte" },
                    { 51, "CG", "COG", 178, "Congo (the)" },
                    { 52, "CD", "COD", 180, "Congo (the Democratic Republic of the)" },
                    { 53, "CK", "COK", 184, "Cook Islands (the)" },
                    { 54, "CR", "CRI", 188, "Costa Rica" },
                    { 55, "HR", "HRV", 191, "Croatia" },
                    { 56, "CU", "CUB", 192, "Cuba" },
                    { 57, "CY", "CYP", 196, "Cyprus" },
                    { 58, "CZ", "CZE", 203, "Czechia" },
                    { 59, "BJ", "BEN", 204, "Benin" },
                    { 60, "DK", "DNK", 208, "Denmark" },
                    { 61, "DM", "DMA", 212, "Dominica" },
                    { 62, "DO", "DOM", 214, "Dominican Republic (the)" },
                    { 63, "EC", "ECU", 218, "Ecuador" },
                    { 64, "SV", "SLV", 222, "El Salvador" },
                    { 65, "GQ", "GNQ", 226, "Equatorial Guinea" },
                    { 66, "ET", "ETH", 231, "Ethiopia" },
                    { 67, "ER", "ERI", 232, "Eritrea" },
                    { 68, "EE", "EST", 233, "Estonia" },
                    { 69, "FO", "FRO", 234, "Faroe Islands (the)" },
                    { 70, "FK", "FLK", 238, "Falkland Islands (the) [Malvinas]" },
                    { 71, "GS", "SGS", 239, "South Georgia and the South Sandwich Islands" },
                    { 72, "FJ", "FJI", 242, "Fiji" },
                    { 73, "FI", "FIN", 246, "Finland" },
                    { 74, "AX", "ALA", 248, "Åland Islands" },
                    { 75, "FR", "FRA", 250, "France" },
                    { 76, "GF", "GUF", 254, "French Guiana" },
                    { 77, "PF", "PYF", 258, "French Polynesia" },
                    { 78, "TF", "ATF", 260, "French Southern Territories (the)" },
                    { 79, "DJ", "DJI", 262, "Djibouti" },
                    { 80, "GA", "GAB", 266, "Gabon" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoAlfa2Code", "IsoAlfa3Code", "IsoNumericCode", "Name" },
                values: new object[,]
                {
                    { 81, "GE", "GEO", 268, "Georgia" },
                    { 82, "GM", "GMB", 270, "Gambia (the)" },
                    { 83, "PS", "PSE", 275, "Palestine, State of" },
                    { 84, "DE", "DEU", 276, "Germany" },
                    { 85, "GH", "GHA", 288, "Ghana" },
                    { 86, "GI", "GIB", 292, "Gibraltar" },
                    { 87, "KI", "KIR", 296, "Kiribati" },
                    { 88, "GR", "GRC", 300, "Greece" },
                    { 89, "GL", "GRL", 304, "Greenland" },
                    { 90, "GD", "GRD", 308, "Grenada" },
                    { 91, "GP", "GLP", 312, "Guadeloupe" },
                    { 92, "GU", "GUM", 316, "Guam" },
                    { 93, "GT", "GTM", 320, "Guatemala" },
                    { 94, "GN", "GIN", 324, "Guinea" },
                    { 95, "GY", "GUY", 328, "Guyana" },
                    { 96, "HT", "HTI", 332, "Haiti" },
                    { 97, "HM", "HMD", 334, "Heard Island and McDonald Islands" },
                    { 98, "VA", "VAT", 336, "Holy See (the)" },
                    { 99, "HN", "HND", 340, "Honduras" },
                    { 100, "HK", "HKG", 344, "Hong Kong" },
                    { 101, "HU", "HUN", 348, "Hungary" },
                    { 102, "IS", "ISL", 352, "Iceland" },
                    { 103, "IN", "IND", 356, "India" },
                    { 104, "ID", "IDN", 360, "Indonesia" },
                    { 105, "IR", "IRN", 364, "Iran (Islamic Republic of)" },
                    { 106, "IQ", "IRQ", 368, "Iraq" },
                    { 107, "IE", "IRL", 372, "Ireland" },
                    { 108, "IL", "ISR", 376, "Israel" },
                    { 109, "IT", "ITA", 380, "Italy" },
                    { 110, "CI", "CIV", 384, "Côte d'Ivoire" },
                    { 111, "JM", "JAM", 388, "Jamaica" },
                    { 112, "JP", "JPN", 392, "Japan" },
                    { 113, "KZ", "KAZ", 398, "Kazakhstan" },
                    { 114, "JO", "JOR", 400, "Jordan" },
                    { 115, "KE", "KEN", 404, "Kenya" },
                    { 116, "KP", "PRK", 408, "Korea (the Democratic People's Republic of)" },
                    { 117, "KR", "KOR", 410, "Korea (the Republic of)" },
                    { 118, "KW", "KWT", 414, "Kuwait" },
                    { 119, "KG", "KGZ", 417, "Kyrgyzstan" },
                    { 120, "LA", "LAO", 418, "Lao People's Democratic Republic (the)" },
                    { 121, "LB", "LBN", 422, "Lebanon" },
                    { 122, "LS", "LSO", 426, "Lesotho" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoAlfa2Code", "IsoAlfa3Code", "IsoNumericCode", "Name" },
                values: new object[,]
                {
                    { 123, "LV", "LVA", 428, "Latvia" },
                    { 124, "LR", "LBR", 430, "Liberia" },
                    { 125, "LY", "LBY", 434, "Libya" },
                    { 126, "LI", "LIE", 438, "Liechtenstein" },
                    { 127, "LT", "LTU", 440, "Lithuania" },
                    { 128, "LU", "LUX", 442, "Luxembourg" },
                    { 129, "MO", "MAC", 446, "Macao" },
                    { 130, "MG", "MDG", 450, "Madagascar" },
                    { 131, "MW", "MWI", 454, "Malawi" },
                    { 132, "MY", "MYS", 458, "Malaysia" },
                    { 133, "MV", "MDV", 462, "Maldives" },
                    { 134, "ML", "MLI", 466, "Mali" },
                    { 135, "MT", "MLT", 470, "Malta" },
                    { 136, "MQ", "MTQ", 474, "Martinique" },
                    { 137, "MR", "MRT", 478, "Mauritania" },
                    { 138, "MU", "MUS", 480, "Mauritius" },
                    { 139, "MX", "MEX", 484, "Mexico" },
                    { 140, "MC", "MCO", 492, "Monaco" },
                    { 141, "MN", "MNG", 496, "Mongolia" },
                    { 142, "MD", "MDA", 498, "Moldova (the Republic of)" },
                    { 143, "ME", "MNE", 499, "Montenegro" },
                    { 144, "MS", "MSR", 500, "Montserrat" },
                    { 145, "MA", "MAR", 504, "Morocco" },
                    { 146, "MZ", "MOZ", 508, "Mozambique" },
                    { 147, "OM", "OMN", 512, "Oman" },
                    { 148, "NA", "NAM", 516, "Namibia" },
                    { 149, "NR", "NRU", 520, "Nauru" },
                    { 150, "NP", "NPL", 524, "Nepal" },
                    { 151, "NL", "NLD", 528, "Netherlands (the)" },
                    { 152, "CW", "CUW", 531, "Curaçao" },
                    { 153, "AW", "ABW", 533, "Aruba" },
                    { 154, "SX", "SXM", 534, "Sint Maarten (Dutch part)" },
                    { 155, "BQ", "BES", 535, "Bonaire, Sint Eustatius and Saba" },
                    { 156, "NC", "NCL", 540, "New Caledonia" },
                    { 157, "VU", "VUT", 548, "Vanuatu" },
                    { 158, "NZ", "NZL", 554, "New Zealand" },
                    { 159, "NI", "NIC", 558, "Nicaragua" },
                    { 160, "NE", "NER", 562, "Niger (the)" },
                    { 161, "NG", "NGA", 566, "Nigeria" },
                    { 162, "NU", "NIU", 570, "Niue" },
                    { 163, "NF", "NFK", 574, "Norfolk Island" },
                    { 164, "NO", "NOR", 578, "Norway" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoAlfa2Code", "IsoAlfa3Code", "IsoNumericCode", "Name" },
                values: new object[,]
                {
                    { 165, "MP", "MNP", 580, "Northern Mariana Islands (the)" },
                    { 166, "UM", "UMI", 581, "United States Minor Outlying Islands (the)" },
                    { 167, "FM", "FSM", 583, "Micronesia (Federated States of)" },
                    { 168, "MH", "MHL", 584, "Marshall Islands (the)" },
                    { 169, "PW", "PLW", 585, "Palau" },
                    { 170, "PK", "PAK", 586, "Pakistan" },
                    { 171, "PA", "PAN", 591, "Panama" },
                    { 172, "PG", "PNG", 598, "Papua New Guinea" },
                    { 173, "PY", "PRY", 600, "Paraguay" },
                    { 174, "PE", "PER", 604, "Peru" },
                    { 175, "PH", "PHL", 608, "Philippines (the)" },
                    { 176, "PN", "PCN", 612, "Pitcairn" },
                    { 177, "PL", "POL", 616, "Poland" },
                    { 178, "PT", "PRT", 620, "Portugal" },
                    { 179, "GW", "GNB", 624, "Guinea-Bissau" },
                    { 180, "TL", "TLS", 626, "Timor-Leste" },
                    { 181, "PR", "PRI", 630, "Puerto Rico" },
                    { 182, "QA", "QAT", 634, "Qatar" },
                    { 183, "RE", "REU", 638, "Réunion" },
                    { 184, "RO", "ROU", 642, "Romania" },
                    { 185, "RU", "RUS", 643, "Russian Federation (the)" },
                    { 186, "RW", "RWA", 646, "Rwanda" },
                    { 187, "BL", "BLM", 652, "Saint Barthélemy" },
                    { 188, "SH", "SHN", 654, "Saint Helena, Ascension and Tristan da Cunha" },
                    { 189, "KN", "KNA", 659, "Saint Kitts and Nevis" },
                    { 190, "AI", "AIA", 660, "Anguilla" },
                    { 191, "LC", "LCA", 662, "Saint Lucia" },
                    { 192, "MF", "MAF", 663, "Saint Martin (French part)" },
                    { 193, "PM", "SPM", 666, "Saint Pierre and Miquelon" },
                    { 194, "VC", "VCT", 670, "Saint Vincent and the Grenadines" },
                    { 195, "SM", "SMR", 674, "San Marino" },
                    { 196, "ST", "STP", 678, "Sao Tome and Principe" },
                    { 197, "SA", "SAU", 682, "Saudi Arabia" },
                    { 198, "SN", "SEN", 686, "Senegal" },
                    { 199, "RS", "SRB", 688, "Serbia" },
                    { 200, "SC", "SYC", 690, "Seychelles" },
                    { 201, "SL", "SLE", 694, "Sierra Leone" },
                    { 202, "SG", "SGP", 702, "Singapore" },
                    { 203, "SK", "SVK", 703, "Slovakia" },
                    { 204, "VN", "VNM", 704, "Viet Nam" },
                    { 205, "SI", "SVN", 705, "Slovenia" },
                    { 206, "SO", "SOM", 706, "Somalia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoAlfa2Code", "IsoAlfa3Code", "IsoNumericCode", "Name" },
                values: new object[,]
                {
                    { 207, "ZA", "ZAF", 710, "South Africa" },
                    { 208, "ZW", "ZWE", 716, "Zimbabwe" },
                    { 209, "ES", "ESP", 724, "Spain" },
                    { 210, "SS", "SSD", 728, "South Sudan" },
                    { 211, "SD", "SDN", 729, "Sudan (the)" },
                    { 212, "EH", "ESH", 732, "Western Sahara*" },
                    { 213, "SR", "SUR", 740, "Suriname" },
                    { 214, "SJ", "SJM", 744, "Svalbard and Jan Mayen" },
                    { 215, "SZ", "SWZ", 748, "Eswatini" },
                    { 216, "SE", "SWE", 752, "Sweden" },
                    { 217, "CH", "CHE", 756, "Switzerland" },
                    { 218, "SY", "SYR", 760, "Syrian Arab Republic (the)" },
                    { 219, "TJ", "TJK", 762, "Tajikistan" },
                    { 220, "TH", "THA", 764, "Thailand" },
                    { 221, "TG", "TGO", 768, "Togo" },
                    { 222, "TK", "TKL", 772, "Tokelau" },
                    { 223, "TO", "TON", 776, "Tonga" },
                    { 224, "TT", "TTO", 780, "Trinidad and Tobago" },
                    { 225, "AE", "ARE", 784, "United Arab Emirates (the)" },
                    { 226, "TN", "TUN", 788, "Tunisia" },
                    { 227, "TR", "TUR", 792, "Türkiye" },
                    { 228, "TM", "TKM", 795, "Turkmenistan" },
                    { 229, "TC", "TCA", 796, "Turks and Caicos Islands (the)" },
                    { 230, "TV", "TUV", 798, "Tuvalu" },
                    { 231, "UG", "UGA", 800, "Uganda" },
                    { 232, "UA", "UKR", 804, "Ukraine" },
                    { 233, "MK", "MKD", 807, "North Macedonia" },
                    { 234, "EG", "EGY", 818, "Egypt" },
                    { 235, "GB", "GBR", 826, "United Kingdom of Great Britain and Northern Ireland (the)" },
                    { 236, "GG", "GGY", 831, "Guernsey" },
                    { 237, "JE", "JEY", 832, "Jersey" },
                    { 238, "IM", "IMN", 833, "Isle of Man" },
                    { 239, "TZ", "TZA", 834, "Tanzania, the United Republic of" },
                    { 240, "US", "USA", 840, "United States of America (the)" },
                    { 241, "VI", "VIR", 850, "Virgin Islands (U.S.)" },
                    { 242, "BF", "BFA", 854, "Burkina Faso" },
                    { 243, "UY", "URY", 858, "Uruguay" },
                    { 244, "UZ", "UZB", 860, "Uzbekistan" },
                    { 245, "VE", "VEN", 862, "Venezuela (Bolivarian Republic of)" },
                    { 246, "WF", "WLF", 876, "Wallis and Futuna" },
                    { 247, "WS", "WSM", 882, "Samoa" },
                    { 248, "YE", "YEM", 887, "Yemen" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsoAlfa2Code", "IsoAlfa3Code", "IsoNumericCode", "Name" },
                values: new object[] { 249, "ZM", "ZMB", 894, "Zambia" });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Developer" },
                    { 3, "Consultant" },
                    { 4, "Accountant" }
                });

            migrationBuilder.InsertData(
                table: "TicketPriorities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 2, "High" }
                });

            migrationBuilder.InsertData(
                table: "TicketStatuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "In Progress" },
                    { 2, "Resolved" },
                    { 3, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Service Request" },
                    { 2, "Bug" },
                    { 3, "Change request" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c838fb22-a99a-42d7-9c00-9bae1b092cfd", "c80cb755-6247-4474-aa26-43a41d78691a" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "JobTitleId", "LastName", "UserId" },
                values: new object[] { 1, "John", 1, "Doe", "c80cb755-6247-4474-aa26-43a41d78691a" });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "ContactId", "EmailAddress", "EmployeeId", "IsMain" },
                values: new object[] { 1, null, "admin@admin.com", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_JobTitleId",
                table: "Contacts",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactId",
                table: "Emails",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmployeeId",
                table: "Emails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_TicketId",
                table: "Files",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerContacts_ContactId",
                table: "PartnerContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_ConsultantId",
                table: "Partners",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_CountryId",
                table: "Partners",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ContactId",
                table: "PhoneNumbers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_EmployeeId",
                table: "PhoneNumbers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketParticipants_UserId",
                table: "TicketParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPosts_StatusId",
                table: "TicketPosts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPosts_TicketId",
                table: "TicketPosts",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPosts_UserId",
                table: "TicketPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PartnerId",
                table: "Tickets",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeId",
                table: "Tickets",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "PartnerContacts");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "TicketParticipants");

            migrationBuilder.DropTable(
                name: "TicketPosts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "TicketPriorities");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "361c7033-86bb-42e0-a264-3f560e1da74d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b35eb07-6f63-41eb-8a44-5178055f3019");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c838fb22-a99a-42d7-9c00-9bae1b092cfd", "c80cb755-6247-4474-aa26-43a41d78691a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c838fb22-a99a-42d7-9c00-9bae1b092cfd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80cb755-6247-4474-aa26-43a41d78691a");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");
        }
    }
}
