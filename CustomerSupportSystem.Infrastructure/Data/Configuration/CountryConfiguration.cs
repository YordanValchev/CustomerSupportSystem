namespace CustomerSupportSystem.Infrastructure.Data.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(GetEntityData());
        }

        private static List<Country> GetEntityData()
        {
            var entityData = new List<Country>()
            {
                new Country()
                {
                    Id = 1,
                    Name = "Afghanistan",
                    IsoAlfa2Code = "AF",
                    IsoAlfa3Code = "AFG",
                    IsoNumericCode = 4
                },
                new Country()
                {
                    Id = 2,
                    Name = "Albania",
                    IsoAlfa2Code = "AL",
                    IsoAlfa3Code = "ALB",
                    IsoNumericCode = 8
                },
                new Country()
                {
                    Id = 3,
                    Name = "Antarctica",
                    IsoAlfa2Code = "AQ",
                    IsoAlfa3Code = "ATA",
                    IsoNumericCode = 10
                },
                new Country()
                {
                    Id = 4,
                    Name = "Algeria",
                    IsoAlfa2Code = "DZ",
                    IsoAlfa3Code = "DZA",
                    IsoNumericCode = 12
                },
                new Country()
                {
                    Id = 5,
                    Name = "American Samoa",
                    IsoAlfa2Code = "AS",
                    IsoAlfa3Code = "ASM",
                    IsoNumericCode = 16
                },
                new Country()
                {
                    Id = 6,
                    Name = "Andorra",
                    IsoAlfa2Code = "AD",
                    IsoAlfa3Code = "AND",
                    IsoNumericCode = 20
                },
                new Country()
                {
                    Id = 7,
                    Name = "Angola",
                    IsoAlfa2Code = "AO",
                    IsoAlfa3Code = "AGO",
                    IsoNumericCode = 24
                },
                new Country()
                {
                    Id = 8,
                    Name = "Antigua and Barbuda",
                    IsoAlfa2Code = "AG",
                    IsoAlfa3Code = "ATG",
                    IsoNumericCode = 28
                },
                new Country()
                {
                    Id = 9,
                    Name = "Azerbaijan",
                    IsoAlfa2Code = "AZ",
                    IsoAlfa3Code = "AZE",
                    IsoNumericCode = 31
                },
                new Country()
                {
                    Id = 10,
                    Name = "Argentina",
                    IsoAlfa2Code = "AR",
                    IsoAlfa3Code = "ARG",
                    IsoNumericCode = 32
                },
                new Country()
                {
                    Id = 11,
                    Name = "Australia",
                    IsoAlfa2Code = "AU",
                    IsoAlfa3Code = "AUS",
                    IsoNumericCode = 36
                },
                new Country()
                {
                    Id = 12,
                    Name = "Austria",
                    IsoAlfa2Code = "AT",
                    IsoAlfa3Code = "AUT",
                    IsoNumericCode = 40
                },
                new Country()
                {
                    Id = 13,
                    Name = "Bahamas (the)",
                    IsoAlfa2Code = "BS",
                    IsoAlfa3Code = "BHS",
                    IsoNumericCode = 44
                },
                new Country()
                {
                    Id = 14,
                    Name = "Bahrain",
                    IsoAlfa2Code = "BH",
                    IsoAlfa3Code = "BHR",
                    IsoNumericCode = 48
                },
                new Country()
                {
                    Id = 15,
                    Name = "Bangladesh",
                    IsoAlfa2Code = "BD",
                    IsoAlfa3Code = "BGD",
                    IsoNumericCode = 50
                },
                new Country()
                {
                    Id = 16,
                    Name = "Armenia",
                    IsoAlfa2Code = "AM",
                    IsoAlfa3Code = "ARM",
                    IsoNumericCode = 51
                },
                new Country()
                {
                    Id = 17,
                    Name = "Barbados",
                    IsoAlfa2Code = "BB",
                    IsoAlfa3Code = "BRB",
                    IsoNumericCode = 52
                },
                new Country()
                {
                    Id = 18,
                    Name = "Belgium",
                    IsoAlfa2Code = "BE",
                    IsoAlfa3Code = "BEL",
                    IsoNumericCode = 56
                },
                new Country()
                {
                    Id = 19,
                    Name = "Bermuda",
                    IsoAlfa2Code = "BM",
                    IsoAlfa3Code = "BMU",
                    IsoNumericCode = 60
                },
                new Country()
                {
                    Id = 20,
                    Name = "Bhutan",
                    IsoAlfa2Code = "BT",
                    IsoAlfa3Code = "BTN",
                    IsoNumericCode = 64
                },
                new Country()
                {
                    Id = 21,
                    Name = "Bolivia (Plurinational State of)",
                    IsoAlfa2Code = "BO",
                    IsoAlfa3Code = "BOL",
                    IsoNumericCode = 68
                },
                new Country()
                {
                    Id = 22,
                    Name = "Bosnia and Herzegovina",
                    IsoAlfa2Code = "BA",
                    IsoAlfa3Code = "BIH",
                    IsoNumericCode = 70
                },
                new Country()
                {
                    Id = 23,
                    Name = "Botswana",
                    IsoAlfa2Code = "BW",
                    IsoAlfa3Code = "BWA",
                    IsoNumericCode = 72
                },
                new Country()
                {
                    Id = 24,
                    Name = "Bouvet Island",
                    IsoAlfa2Code = "BV",
                    IsoAlfa3Code = "BVT",
                    IsoNumericCode = 74
                },
                new Country()
                {
                    Id = 25,
                    Name = "Brazil",
                    IsoAlfa2Code = "BR",
                    IsoAlfa3Code = "BRA",
                    IsoNumericCode = 76
                },
                new Country()
                {
                    Id = 26,
                    Name = "Belize",
                    IsoAlfa2Code = "BZ",
                    IsoAlfa3Code = "BLZ",
                    IsoNumericCode = 84
                },
                new Country()
                {
                    Id = 27,
                    Name = "British Indian Ocean Territory (the)",
                    IsoAlfa2Code = "IO",
                    IsoAlfa3Code = "IOT",
                    IsoNumericCode = 86
                },
                new Country()
                {
                    Id = 28,
                    Name = "Solomon Islands",
                    IsoAlfa2Code = "SB",
                    IsoAlfa3Code = "SLB",
                    IsoNumericCode = 90
                },
                new Country()
                {
                    Id = 29,
                    Name = "Virgin Islands (British)",
                    IsoAlfa2Code = "VG",
                    IsoAlfa3Code = "VGB",
                    IsoNumericCode = 92
                },
                new Country()
                {
                    Id = 30,
                    Name = "Brunei Darussalam",
                    IsoAlfa2Code = "BN",
                    IsoAlfa3Code = "BRN",
                    IsoNumericCode = 96
                },
                new Country()
                {
                    Id = 31,
                    Name = "Bulgaria",
                    IsoAlfa2Code = "BG",
                    IsoAlfa3Code = "BGR",
                    IsoNumericCode = 100
                },
                new Country()
                {
                    Id = 32,
                    Name = "Myanmar",
                    IsoAlfa2Code = "MM",
                    IsoAlfa3Code = "MMR",
                    IsoNumericCode = 104
                },
                new Country()
                {
                    Id = 33,
                    Name = "Burundi",
                    IsoAlfa2Code = "BI",
                    IsoAlfa3Code = "BDI",
                    IsoNumericCode = 108
                },
                new Country()
                {
                    Id = 34,
                    Name = "Belarus",
                    IsoAlfa2Code = "BY",
                    IsoAlfa3Code = "BLR",
                    IsoNumericCode = 112
                },
                new Country()
                {
                    Id = 35,
                    Name = "Cambodia",
                    IsoAlfa2Code = "KH",
                    IsoAlfa3Code = "KHM",
                    IsoNumericCode = 116
                },
                new Country()
                {
                    Id = 36,
                    Name = "Cameroon",
                    IsoAlfa2Code = "CM",
                    IsoAlfa3Code = "CMR",
                    IsoNumericCode = 120
                },
                new Country()
                {
                    Id = 37,
                    Name = "Canada",
                    IsoAlfa2Code = "CA",
                    IsoAlfa3Code = "CAN",
                    IsoNumericCode = 124
                },
                new Country()
                {
                    Id = 38,
                    Name = "Cabo Verde",
                    IsoAlfa2Code = "CV",
                    IsoAlfa3Code = "CPV",
                    IsoNumericCode = 132
                },
                new Country()
                {
                    Id = 39,
                    Name = "Cayman Islands (the)",
                    IsoAlfa2Code = "KY",
                    IsoAlfa3Code = "CYM",
                    IsoNumericCode = 136
                },
                new Country()
                {
                    Id = 40,
                    Name = "Central African Republic (the)",
                    IsoAlfa2Code = "CF",
                    IsoAlfa3Code = "CAF",
                    IsoNumericCode = 140
                },
                new Country()
                {
                    Id = 41,
                    Name = "Sri Lanka",
                    IsoAlfa2Code = "LK",
                    IsoAlfa3Code = "LKA",
                    IsoNumericCode = 144
                },
                new Country()
                {
                    Id = 42,
                    Name = "Chad",
                    IsoAlfa2Code = "TD",
                    IsoAlfa3Code = "TCD",
                    IsoNumericCode = 148
                },
                new Country()
                {
                    Id = 43,
                    Name = "Chile",
                    IsoAlfa2Code = "CL",
                    IsoAlfa3Code = "CHL",
                    IsoNumericCode = 152
                },
                new Country()
                {
                    Id = 44,
                    Name = "China",
                    IsoAlfa2Code = "CN",
                    IsoAlfa3Code = "CHN",
                    IsoNumericCode = 156
                },
                new Country()
                {
                    Id = 45,
                    Name = "Taiwan (Province of China)",
                    IsoAlfa2Code = "TW",
                    IsoAlfa3Code = "TWN",
                    IsoNumericCode = 158
                },
                new Country()
                {
                    Id = 46,
                    Name = "Christmas Island",
                    IsoAlfa2Code = "CX",
                    IsoAlfa3Code = "CXR",
                    IsoNumericCode = 162
                },
                new Country()
                {
                    Id = 47,
                    Name = "Cocos (Keeling) Islands (the)",
                    IsoAlfa2Code = "CC",
                    IsoAlfa3Code = "CCK",
                    IsoNumericCode = 166
                },
                new Country()
                {
                    Id = 48,
                    Name = "Colombia",
                    IsoAlfa2Code = "CO",
                    IsoAlfa3Code = "COL",
                    IsoNumericCode = 170
                },
                new Country()
                {
                    Id = 49,
                    Name = "Comoros (the)",
                    IsoAlfa2Code = "KM",
                    IsoAlfa3Code = "COM",
                    IsoNumericCode = 174
                },
                new Country()
                {
                    Id = 50,
                    Name = "Mayotte",
                    IsoAlfa2Code = "YT",
                    IsoAlfa3Code = "MYT",
                    IsoNumericCode = 175
                },
                new Country()
                {
                    Id = 51,
                    Name = "Congo (the)",
                    IsoAlfa2Code = "CG",
                    IsoAlfa3Code = "COG",
                    IsoNumericCode = 178
                },
                new Country()
                {
                    Id = 52,
                    Name = "Congo (the Democratic Republic of the)",
                    IsoAlfa2Code = "CD",
                    IsoAlfa3Code = "COD",
                    IsoNumericCode = 180
                },
                new Country()
                {
                    Id = 53,
                    Name = "Cook Islands (the)",
                    IsoAlfa2Code = "CK",
                    IsoAlfa3Code = "COK",
                    IsoNumericCode = 184
                },
                new Country()
                {
                    Id = 54,
                    Name = "Costa Rica",
                    IsoAlfa2Code = "CR",
                    IsoAlfa3Code = "CRI",
                    IsoNumericCode = 188
                },
                new Country()
                {
                    Id = 55,
                    Name = "Croatia",
                    IsoAlfa2Code = "HR",
                    IsoAlfa3Code = "HRV",
                    IsoNumericCode = 191
                },
                new Country()
                {
                    Id = 56,
                    Name = "Cuba",
                    IsoAlfa2Code = "CU",
                    IsoAlfa3Code = "CUB",
                    IsoNumericCode = 192
                },
                new Country()
                {
                    Id = 57,
                    Name = "Cyprus",
                    IsoAlfa2Code = "CY",
                    IsoAlfa3Code = "CYP",
                    IsoNumericCode = 196
                },
                new Country()
                {
                    Id = 58,
                    Name = "Czechia",
                    IsoAlfa2Code = "CZ",
                    IsoAlfa3Code = "CZE",
                    IsoNumericCode = 203
                },
                new Country()
                {
                    Id = 59,
                    Name = "Benin",
                    IsoAlfa2Code = "BJ",
                    IsoAlfa3Code = "BEN",
                    IsoNumericCode = 204
                },
                new Country()
                {
                    Id = 60,
                    Name = "Denmark",
                    IsoAlfa2Code = "DK",
                    IsoAlfa3Code = "DNK",
                    IsoNumericCode = 208
                },
                new Country()
                {
                    Id = 61,
                    Name = "Dominica",
                    IsoAlfa2Code = "DM",
                    IsoAlfa3Code = "DMA",
                    IsoNumericCode = 212
                },
                new Country()
                {
                    Id = 62,
                    Name = "Dominican Republic (the)",
                    IsoAlfa2Code = "DO",
                    IsoAlfa3Code = "DOM",
                    IsoNumericCode = 214
                },
                new Country()
                {
                    Id = 63,
                    Name = "Ecuador",
                    IsoAlfa2Code = "EC",
                    IsoAlfa3Code = "ECU",
                    IsoNumericCode = 218
                },
                new Country()
                {
                    Id = 64,
                    Name = "El Salvador",
                    IsoAlfa2Code = "SV",
                    IsoAlfa3Code = "SLV",
                    IsoNumericCode = 222
                },
                new Country()
                {
                    Id = 65,
                    Name = "Equatorial Guinea",
                    IsoAlfa2Code = "GQ",
                    IsoAlfa3Code = "GNQ",
                    IsoNumericCode = 226
                },
                new Country()
                {
                    Id = 66,
                    Name = "Ethiopia",
                    IsoAlfa2Code = "ET",
                    IsoAlfa3Code = "ETH",
                    IsoNumericCode = 231
                },
                new Country()
                {
                    Id = 67,
                    Name = "Eritrea",
                    IsoAlfa2Code = "ER",
                    IsoAlfa3Code = "ERI",
                    IsoNumericCode = 232
                },
                new Country()
                {
                    Id = 68,
                    Name = "Estonia",
                    IsoAlfa2Code = "EE",
                    IsoAlfa3Code = "EST",
                    IsoNumericCode = 233
                },
                new Country()
                {
                    Id = 69,
                    Name = "Faroe Islands (the)",
                    IsoAlfa2Code = "FO",
                    IsoAlfa3Code = "FRO",
                    IsoNumericCode = 234
                },
                new Country()
                {
                    Id = 70,
                    Name = "Falkland Islands (the) [Malvinas]",
                    IsoAlfa2Code = "FK",
                    IsoAlfa3Code = "FLK",
                    IsoNumericCode = 238
                },
                new Country()
                {
                    Id = 71,
                    Name = "South Georgia and the South Sandwich Islands",
                    IsoAlfa2Code = "GS",
                    IsoAlfa3Code = "SGS",
                    IsoNumericCode = 239
                },
                new Country()
                {
                    Id = 72,
                    Name = "Fiji",
                    IsoAlfa2Code = "FJ",
                    IsoAlfa3Code = "FJI",
                    IsoNumericCode = 242
                },
                new Country()
                {
                    Id = 73,
                    Name = "Finland",
                    IsoAlfa2Code = "FI",
                    IsoAlfa3Code = "FIN",
                    IsoNumericCode = 246
                },
                new Country()
                {
                    Id = 74,
                    Name = "Åland Islands",
                    IsoAlfa2Code = "AX",
                    IsoAlfa3Code = "ALA",
                    IsoNumericCode = 248
                },
                new Country()
                {
                    Id = 75,
                    Name = "France",
                    IsoAlfa2Code = "FR",
                    IsoAlfa3Code = "FRA",
                    IsoNumericCode = 250
                },
                new Country()
                {
                    Id = 76,
                    Name = "French Guiana",
                    IsoAlfa2Code = "GF",
                    IsoAlfa3Code = "GUF",
                    IsoNumericCode = 254
                },
                new Country()
                {
                    Id = 77,
                    Name = "French Polynesia",
                    IsoAlfa2Code = "PF",
                    IsoAlfa3Code = "PYF",
                    IsoNumericCode = 258
                },
                new Country()
                {
                    Id = 78,
                    Name = "French Southern Territories (the)",
                    IsoAlfa2Code = "TF",
                    IsoAlfa3Code = "ATF",
                    IsoNumericCode = 260
                },
                new Country()
                {
                    Id = 79,
                    Name = "Djibouti",
                    IsoAlfa2Code = "DJ",
                    IsoAlfa3Code = "DJI",
                    IsoNumericCode = 262
                },
                new Country()
                {
                    Id = 80,
                    Name = "Gabon",
                    IsoAlfa2Code = "GA",
                    IsoAlfa3Code = "GAB",
                    IsoNumericCode = 266
                },
                new Country()
                {
                    Id = 81,
                    Name = "Georgia",
                    IsoAlfa2Code = "GE",
                    IsoAlfa3Code = "GEO",
                    IsoNumericCode = 268
                },
                new Country()
                {
                    Id = 82,
                    Name = "Gambia (the)",
                    IsoAlfa2Code = "GM",
                    IsoAlfa3Code = "GMB",
                    IsoNumericCode = 270
                },
                new Country()
                {
                    Id = 83,
                    Name = "Palestine, State of",
                    IsoAlfa2Code = "PS",
                    IsoAlfa3Code = "PSE",
                    IsoNumericCode = 275
                },
                new Country()
                {
                    Id = 84,
                    Name = "Germany",
                    IsoAlfa2Code = "DE",
                    IsoAlfa3Code = "DEU",
                    IsoNumericCode = 276
                },
                new Country()
                {
                    Id = 85,
                    Name = "Ghana",
                    IsoAlfa2Code = "GH",
                    IsoAlfa3Code = "GHA",
                    IsoNumericCode = 288
                },
                new Country()
                {
                    Id = 86,
                    Name = "Gibraltar",
                    IsoAlfa2Code = "GI",
                    IsoAlfa3Code = "GIB",
                    IsoNumericCode = 292
                },
                new Country()
                {
                    Id = 87,
                    Name = "Kiribati",
                    IsoAlfa2Code = "KI",
                    IsoAlfa3Code = "KIR",
                    IsoNumericCode = 296
                },
                new Country()
                {
                    Id = 88,
                    Name = "Greece",
                    IsoAlfa2Code = "GR",
                    IsoAlfa3Code = "GRC",
                    IsoNumericCode = 300
                },
                new Country()
                {
                    Id = 89,
                    Name = "Greenland",
                    IsoAlfa2Code = "GL",
                    IsoAlfa3Code = "GRL",
                    IsoNumericCode = 304
                },
                new Country()
                {
                    Id = 90,
                    Name = "Grenada",
                    IsoAlfa2Code = "GD",
                    IsoAlfa3Code = "GRD",
                    IsoNumericCode = 308
                },
                new Country()
                {
                    Id = 91,
                    Name = "Guadeloupe",
                    IsoAlfa2Code = "GP",
                    IsoAlfa3Code = "GLP",
                    IsoNumericCode = 312
                },
                new Country()
                {
                    Id = 92,
                    Name = "Guam",
                    IsoAlfa2Code = "GU",
                    IsoAlfa3Code = "GUM",
                    IsoNumericCode = 316
                },
                new Country()
                {
                    Id = 93,
                    Name = "Guatemala",
                    IsoAlfa2Code = "GT",
                    IsoAlfa3Code = "GTM",
                    IsoNumericCode = 320
                },
                new Country()
                {
                    Id = 94,
                    Name = "Guinea",
                    IsoAlfa2Code = "GN",
                    IsoAlfa3Code = "GIN",
                    IsoNumericCode = 324
                },
                new Country()
                {
                    Id = 95,
                    Name = "Guyana",
                    IsoAlfa2Code = "GY",
                    IsoAlfa3Code = "GUY",
                    IsoNumericCode = 328
                },
                new Country()
                {
                    Id = 96,
                    Name = "Haiti",
                    IsoAlfa2Code = "HT",
                    IsoAlfa3Code = "HTI",
                    IsoNumericCode = 332
                },
                new Country()
                {
                    Id = 97,
                    Name = "Heard Island and McDonald Islands",
                    IsoAlfa2Code = "HM",
                    IsoAlfa3Code = "HMD",
                    IsoNumericCode = 334
                },
                new Country()
                {
                    Id = 98,
                    Name = "Holy See (the)",
                    IsoAlfa2Code = "VA",
                    IsoAlfa3Code = "VAT",
                    IsoNumericCode = 336
                },
                new Country()
                {
                    Id = 99,
                    Name = "Honduras",
                    IsoAlfa2Code = "HN",
                    IsoAlfa3Code = "HND",
                    IsoNumericCode = 340
                },
                new Country()
                {
                    Id = 100,
                    Name = "Hong Kong",
                    IsoAlfa2Code = "HK",
                    IsoAlfa3Code = "HKG",
                    IsoNumericCode = 344
                },
                new Country()
                {
                    Id = 101,
                    Name = "Hungary",
                    IsoAlfa2Code = "HU",
                    IsoAlfa3Code = "HUN",
                    IsoNumericCode = 348
                },
                new Country()
                {
                    Id = 102,
                    Name = "Iceland",
                    IsoAlfa2Code = "IS",
                    IsoAlfa3Code = "ISL",
                    IsoNumericCode = 352
                },
                new Country()
                {
                    Id = 103,
                    Name = "India",
                    IsoAlfa2Code = "IN",
                    IsoAlfa3Code = "IND",
                    IsoNumericCode = 356
                },
                new Country()
                {
                    Id = 104,
                    Name = "Indonesia",
                    IsoAlfa2Code = "ID",
                    IsoAlfa3Code = "IDN",
                    IsoNumericCode = 360
                },
                new Country()
                {
                    Id = 105,
                    Name = "Iran (Islamic Republic of)",
                    IsoAlfa2Code = "IR",
                    IsoAlfa3Code = "IRN",
                    IsoNumericCode = 364
                },
                new Country()
                {
                    Id = 106,
                    Name = "Iraq",
                    IsoAlfa2Code = "IQ",
                    IsoAlfa3Code = "IRQ",
                    IsoNumericCode = 368
                },
                new Country()
                {
                    Id = 107,
                    Name = "Ireland",
                    IsoAlfa2Code = "IE",
                    IsoAlfa3Code = "IRL",
                    IsoNumericCode = 372
                },
                new Country()
                {
                    Id = 108,
                    Name = "Israel",
                    IsoAlfa2Code = "IL",
                    IsoAlfa3Code = "ISR",
                    IsoNumericCode = 376
                },
                new Country()
                {
                    Id = 109,
                    Name = "Italy",
                    IsoAlfa2Code = "IT",
                    IsoAlfa3Code = "ITA",
                    IsoNumericCode = 380
                },
                new Country()
                {
                    Id = 110,
                    Name = "Côte d'Ivoire",
                    IsoAlfa2Code = "CI",
                    IsoAlfa3Code = "CIV",
                    IsoNumericCode = 384
                },
                new Country()
                {
                    Id = 111,
                    Name = "Jamaica",
                    IsoAlfa2Code = "JM",
                    IsoAlfa3Code = "JAM",
                    IsoNumericCode = 388
                },
                new Country()
                {
                    Id = 112,
                    Name = "Japan",
                    IsoAlfa2Code = "JP",
                    IsoAlfa3Code = "JPN",
                    IsoNumericCode = 392
                },
                new Country()
                {
                    Id = 113,
                    Name = "Kazakhstan",
                    IsoAlfa2Code = "KZ",
                    IsoAlfa3Code = "KAZ",
                    IsoNumericCode = 398
                },
                new Country()
                {
                    Id = 114,
                    Name = "Jordan",
                    IsoAlfa2Code = "JO",
                    IsoAlfa3Code = "JOR",
                    IsoNumericCode = 400
                },
                new Country()
                {
                    Id = 115,
                    Name = "Kenya",
                    IsoAlfa2Code = "KE",
                    IsoAlfa3Code = "KEN",
                    IsoNumericCode = 404
                },
                new Country()
                {
                    Id = 116,
                    Name = "Korea (the Democratic People's Republic of)",
                    IsoAlfa2Code = "KP",
                    IsoAlfa3Code = "PRK",
                    IsoNumericCode = 408
                },
                new Country()
                {
                    Id = 117,
                    Name = "Korea (the Republic of)",
                    IsoAlfa2Code = "KR",
                    IsoAlfa3Code = "KOR",
                    IsoNumericCode = 410
                },
                new Country()
                {
                    Id = 118,
                    Name = "Kuwait",
                    IsoAlfa2Code = "KW",
                    IsoAlfa3Code = "KWT",
                    IsoNumericCode = 414
                },
                new Country()
                {
                    Id = 119,
                    Name = "Kyrgyzstan",
                    IsoAlfa2Code = "KG",
                    IsoAlfa3Code = "KGZ",
                    IsoNumericCode = 417
                },
                new Country()
                {
                    Id = 120,
                    Name = "Lao People's Democratic Republic (the)",
                    IsoAlfa2Code = "LA",
                    IsoAlfa3Code = "LAO",
                    IsoNumericCode = 418
                },
                new Country()
                {
                    Id = 121,
                    Name = "Lebanon",
                    IsoAlfa2Code = "LB",
                    IsoAlfa3Code = "LBN",
                    IsoNumericCode = 422
                },
                new Country()
                {
                    Id = 122,
                    Name = "Lesotho",
                    IsoAlfa2Code = "LS",
                    IsoAlfa3Code = "LSO",
                    IsoNumericCode = 426
                },
                new Country()
                {
                    Id = 123,
                    Name = "Latvia",
                    IsoAlfa2Code = "LV",
                    IsoAlfa3Code = "LVA",
                    IsoNumericCode = 428
                },
                new Country()
                {
                    Id = 124,
                    Name = "Liberia",
                    IsoAlfa2Code = "LR",
                    IsoAlfa3Code = "LBR",
                    IsoNumericCode = 430
                },
                new Country()
                {
                    Id = 125,
                    Name = "Libya",
                    IsoAlfa2Code = "LY",
                    IsoAlfa3Code = "LBY",
                    IsoNumericCode = 434
                },
                new Country()
                {
                    Id = 126,
                    Name = "Liechtenstein",
                    IsoAlfa2Code = "LI",
                    IsoAlfa3Code = "LIE",
                    IsoNumericCode = 438
                },
                new Country()
                {
                    Id = 127,
                    Name = "Lithuania",
                    IsoAlfa2Code = "LT",
                    IsoAlfa3Code = "LTU",
                    IsoNumericCode = 440
                },
                new Country()
                {
                    Id = 128,
                    Name = "Luxembourg",
                    IsoAlfa2Code = "LU",
                    IsoAlfa3Code = "LUX",
                    IsoNumericCode = 442
                },
                new Country()
                {
                    Id = 129,
                    Name = "Macao",
                    IsoAlfa2Code = "MO",
                    IsoAlfa3Code = "MAC",
                    IsoNumericCode = 446
                },
                new Country()
                {
                    Id = 130,
                    Name = "Madagascar",
                    IsoAlfa2Code = "MG",
                    IsoAlfa3Code = "MDG",
                    IsoNumericCode = 450
                },
                new Country()
                {
                    Id = 131,
                    Name = "Malawi",
                    IsoAlfa2Code = "MW",
                    IsoAlfa3Code = "MWI",
                    IsoNumericCode = 454
                },
                new Country()
                {
                    Id = 132,
                    Name = "Malaysia",
                    IsoAlfa2Code = "MY",
                    IsoAlfa3Code = "MYS",
                    IsoNumericCode = 458
                },
                new Country()
                {
                    Id = 133,
                    Name = "Maldives",
                    IsoAlfa2Code = "MV",
                    IsoAlfa3Code = "MDV",
                    IsoNumericCode = 462
                },
                new Country()
                {
                    Id = 134,
                    Name = "Mali",
                    IsoAlfa2Code = "ML",
                    IsoAlfa3Code = "MLI",
                    IsoNumericCode = 466
                },
                new Country()
                {
                    Id = 135,
                    Name = "Malta",
                    IsoAlfa2Code = "MT",
                    IsoAlfa3Code = "MLT",
                    IsoNumericCode = 470
                },
                new Country()
                {
                    Id = 136,
                    Name = "Martinique",
                    IsoAlfa2Code = "MQ",
                    IsoAlfa3Code = "MTQ",
                    IsoNumericCode = 474
                },
                new Country()
                {
                    Id = 137,
                    Name = "Mauritania",
                    IsoAlfa2Code = "MR",
                    IsoAlfa3Code = "MRT",
                    IsoNumericCode = 478
                },
                new Country()
                {
                    Id = 138,
                    Name = "Mauritius",
                    IsoAlfa2Code = "MU",
                    IsoAlfa3Code = "MUS",
                    IsoNumericCode = 480
                },
                new Country()
                {
                    Id = 139,
                    Name = "Mexico",
                    IsoAlfa2Code = "MX",
                    IsoAlfa3Code = "MEX",
                    IsoNumericCode = 484
                },
                new Country()
                {
                    Id = 140,
                    Name = "Monaco",
                    IsoAlfa2Code = "MC",
                    IsoAlfa3Code = "MCO",
                    IsoNumericCode = 492
                },
                new Country()
                {
                    Id = 141,
                    Name = "Mongolia",
                    IsoAlfa2Code = "MN",
                    IsoAlfa3Code = "MNG",
                    IsoNumericCode = 496
                },
                new Country()
                {
                    Id = 142,
                    Name = "Moldova (the Republic of)",
                    IsoAlfa2Code = "MD",
                    IsoAlfa3Code = "MDA",
                    IsoNumericCode = 498
                },
                new Country()
                {
                    Id = 143,
                    Name = "Montenegro",
                    IsoAlfa2Code = "ME",
                    IsoAlfa3Code = "MNE",
                    IsoNumericCode = 499
                },
                new Country()
                {
                    Id = 144,
                    Name = "Montserrat",
                    IsoAlfa2Code = "MS",
                    IsoAlfa3Code = "MSR",
                    IsoNumericCode = 500
                },
                new Country()
                {
                    Id = 145,
                    Name = "Morocco",
                    IsoAlfa2Code = "MA",
                    IsoAlfa3Code = "MAR",
                    IsoNumericCode = 504
                },
                new Country()
                {
                    Id = 146,
                    Name = "Mozambique",
                    IsoAlfa2Code = "MZ",
                    IsoAlfa3Code = "MOZ",
                    IsoNumericCode = 508
                },
                new Country()
                {
                    Id = 147,
                    Name = "Oman",
                    IsoAlfa2Code = "OM",
                    IsoAlfa3Code = "OMN",
                    IsoNumericCode = 512
                },
                new Country()
                {
                    Id = 148,
                    Name = "Namibia",
                    IsoAlfa2Code = "NA",
                    IsoAlfa3Code = "NAM",
                    IsoNumericCode = 516
                },
                new Country()
                {
                    Id = 149,
                    Name = "Nauru",
                    IsoAlfa2Code = "NR",
                    IsoAlfa3Code = "NRU",
                    IsoNumericCode = 520
                },
                new Country()
                {
                    Id = 150,
                    Name = "Nepal",
                    IsoAlfa2Code = "NP",
                    IsoAlfa3Code = "NPL",
                    IsoNumericCode = 524
                },
                new Country()
                {
                    Id = 151,
                    Name = "Netherlands (the)",
                    IsoAlfa2Code = "NL",
                    IsoAlfa3Code = "NLD",
                    IsoNumericCode = 528
                },
                new Country()
                {
                    Id = 152,
                    Name = "Curaçao",
                    IsoAlfa2Code = "CW",
                    IsoAlfa3Code = "CUW",
                    IsoNumericCode = 531
                },
                new Country()
                {
                    Id = 153,
                    Name = "Aruba",
                    IsoAlfa2Code = "AW",
                    IsoAlfa3Code = "ABW",
                    IsoNumericCode = 533
                },
                new Country()
                {
                    Id = 154,
                    Name = "Sint Maarten (Dutch part)",
                    IsoAlfa2Code = "SX",
                    IsoAlfa3Code = "SXM",
                    IsoNumericCode = 534
                },
                new Country()
                {
                    Id = 155,
                    Name = "Bonaire, Sint Eustatius and Saba",
                    IsoAlfa2Code = "BQ",
                    IsoAlfa3Code = "BES",
                    IsoNumericCode = 535
                },
                new Country()
                {
                    Id = 156,
                    Name = "New Caledonia",
                    IsoAlfa2Code = "NC",
                    IsoAlfa3Code = "NCL",
                    IsoNumericCode = 540
                },
                new Country()
                {
                    Id = 157,
                    Name = "Vanuatu",
                    IsoAlfa2Code = "VU",
                    IsoAlfa3Code = "VUT",
                    IsoNumericCode = 548
                },
                new Country()
                {
                    Id = 158,
                    Name = "New Zealand",
                    IsoAlfa2Code = "NZ",
                    IsoAlfa3Code = "NZL",
                    IsoNumericCode = 554
                },
                new Country()
                {
                    Id = 159,
                    Name = "Nicaragua",
                    IsoAlfa2Code = "NI",
                    IsoAlfa3Code = "NIC",
                    IsoNumericCode = 558
                },
                new Country()
                {
                    Id = 160,
                    Name = "Niger (the)",
                    IsoAlfa2Code = "NE",
                    IsoAlfa3Code = "NER",
                    IsoNumericCode = 562
                },
                new Country()
                {
                    Id = 161,
                    Name = "Nigeria",
                    IsoAlfa2Code = "NG",
                    IsoAlfa3Code = "NGA",
                    IsoNumericCode = 566
                },
                new Country()
                {
                    Id = 162,
                    Name = "Niue",
                    IsoAlfa2Code = "NU",
                    IsoAlfa3Code = "NIU",
                    IsoNumericCode = 570
                },
                new Country()
                {
                    Id = 163,
                    Name = "Norfolk Island",
                    IsoAlfa2Code = "NF",
                    IsoAlfa3Code = "NFK",
                    IsoNumericCode = 574
                },
                new Country()
                {
                    Id = 164,
                    Name = "Norway",
                    IsoAlfa2Code = "NO",
                    IsoAlfa3Code = "NOR",
                    IsoNumericCode = 578
                },
                new Country()
                {
                    Id = 165,
                    Name = "Northern Mariana Islands (the)",
                    IsoAlfa2Code = "MP",
                    IsoAlfa3Code = "MNP",
                    IsoNumericCode = 580
                },
                new Country()
                {
                    Id = 166,
                    Name = "United States Minor Outlying Islands (the)",
                    IsoAlfa2Code = "UM",
                    IsoAlfa3Code = "UMI",
                    IsoNumericCode = 581
                },
                new Country()
                {
                    Id = 167,
                    Name = "Micronesia (Federated States of)",
                    IsoAlfa2Code = "FM",
                    IsoAlfa3Code = "FSM",
                    IsoNumericCode = 583
                },
                new Country()
                {
                    Id = 168,
                    Name = "Marshall Islands (the)",
                    IsoAlfa2Code = "MH",
                    IsoAlfa3Code = "MHL",
                    IsoNumericCode = 584
                },
                new Country()
                {
                    Id = 169,
                    Name = "Palau",
                    IsoAlfa2Code = "PW",
                    IsoAlfa3Code = "PLW",
                    IsoNumericCode = 585
                },
                new Country()
                {
                    Id = 170,
                    Name = "Pakistan",
                    IsoAlfa2Code = "PK",
                    IsoAlfa3Code = "PAK",
                    IsoNumericCode = 586
                },
                new Country()
                {
                    Id = 171,
                    Name = "Panama",
                    IsoAlfa2Code = "PA",
                    IsoAlfa3Code = "PAN",
                    IsoNumericCode = 591
                },
                new Country()
                {
                    Id = 172,
                    Name = "Papua New Guinea",
                    IsoAlfa2Code = "PG",
                    IsoAlfa3Code = "PNG",
                    IsoNumericCode = 598
                },
                new Country()
                {
                    Id = 173,
                    Name = "Paraguay",
                    IsoAlfa2Code = "PY",
                    IsoAlfa3Code = "PRY",
                    IsoNumericCode = 600
                },
                new Country()
                {
                    Id = 174,
                    Name = "Peru",
                    IsoAlfa2Code = "PE",
                    IsoAlfa3Code = "PER",
                    IsoNumericCode = 604
                },
                new Country()
                {
                    Id = 175,
                    Name = "Philippines (the)",
                    IsoAlfa2Code = "PH",
                    IsoAlfa3Code = "PHL",
                    IsoNumericCode = 608
                },
                new Country()
                {
                    Id = 176,
                    Name = "Pitcairn",
                    IsoAlfa2Code = "PN",
                    IsoAlfa3Code = "PCN",
                    IsoNumericCode = 612
                },
                new Country()
                {
                    Id = 177,
                    Name = "Poland",
                    IsoAlfa2Code = "PL",
                    IsoAlfa3Code = "POL",
                    IsoNumericCode = 616
                },
                new Country()
                {
                    Id = 178,
                    Name = "Portugal",
                    IsoAlfa2Code = "PT",
                    IsoAlfa3Code = "PRT",
                    IsoNumericCode = 620
                },
                new Country()
                {
                    Id = 179,
                    Name = "Guinea-Bissau",
                    IsoAlfa2Code = "GW",
                    IsoAlfa3Code = "GNB",
                    IsoNumericCode = 624
                },
                new Country()
                {
                    Id = 180,
                    Name = "Timor-Leste",
                    IsoAlfa2Code = "TL",
                    IsoAlfa3Code = "TLS",
                    IsoNumericCode = 626
                },
                new Country()
                {
                    Id = 181,
                    Name = "Puerto Rico",
                    IsoAlfa2Code = "PR",
                    IsoAlfa3Code = "PRI",
                    IsoNumericCode = 630
                },
                new Country()
                {
                    Id = 182,
                    Name = "Qatar",
                    IsoAlfa2Code = "QA",
                    IsoAlfa3Code = "QAT",
                    IsoNumericCode = 634
                },
                new Country()
                {
                    Id = 183,
                    Name = "Réunion",
                    IsoAlfa2Code = "RE",
                    IsoAlfa3Code = "REU",
                    IsoNumericCode = 638
                },
                new Country()
                {
                    Id = 184,
                    Name = "Romania",
                    IsoAlfa2Code = "RO",
                    IsoAlfa3Code = "ROU",
                    IsoNumericCode = 642
                },
                new Country()
                {
                    Id = 185,
                    Name = "Russian Federation (the)",
                    IsoAlfa2Code = "RU",
                    IsoAlfa3Code = "RUS",
                    IsoNumericCode = 643
                },
                new Country()
                {
                    Id = 186,
                    Name = "Rwanda",
                    IsoAlfa2Code = "RW",
                    IsoAlfa3Code = "RWA",
                    IsoNumericCode = 646
                },
                new Country()
                {
                    Id = 187,
                    Name = "Saint Barthélemy",
                    IsoAlfa2Code = "BL",
                    IsoAlfa3Code = "BLM",
                    IsoNumericCode = 652
                },
                new Country()
                {
                    Id = 188,
                    Name = "Saint Helena, Ascension and Tristan da Cunha",
                    IsoAlfa2Code = "SH",
                    IsoAlfa3Code = "SHN",
                    IsoNumericCode = 654
                },
                new Country()
                {
                    Id = 189,
                    Name = "Saint Kitts and Nevis",
                    IsoAlfa2Code = "KN",
                    IsoAlfa3Code = "KNA",
                    IsoNumericCode = 659
                },
                new Country()
                {
                    Id = 190,
                    Name = "Anguilla",
                    IsoAlfa2Code = "AI",
                    IsoAlfa3Code = "AIA",
                    IsoNumericCode = 660
                },
                new Country()
                {
                    Id = 191,
                    Name = "Saint Lucia",
                    IsoAlfa2Code = "LC",
                    IsoAlfa3Code = "LCA",
                    IsoNumericCode = 662
                },
                new Country()
                {
                    Id = 192,
                    Name = "Saint Martin (French part)",
                    IsoAlfa2Code = "MF",
                    IsoAlfa3Code = "MAF",
                    IsoNumericCode = 663
                },
                new Country()
                {
                    Id = 193,
                    Name = "Saint Pierre and Miquelon",
                    IsoAlfa2Code = "PM",
                    IsoAlfa3Code = "SPM",
                    IsoNumericCode = 666
                },
                new Country()
                {
                    Id = 194,
                    Name = "Saint Vincent and the Grenadines",
                    IsoAlfa2Code = "VC",
                    IsoAlfa3Code = "VCT",
                    IsoNumericCode = 670
                },
                new Country()
                {
                    Id = 195,
                    Name = "San Marino",
                    IsoAlfa2Code = "SM",
                    IsoAlfa3Code = "SMR",
                    IsoNumericCode = 674
                },
                new Country()
                {
                    Id = 196,
                    Name = "Sao Tome and Principe",
                    IsoAlfa2Code = "ST",
                    IsoAlfa3Code = "STP",
                    IsoNumericCode = 678
                },
                new Country()
                {
                    Id = 197,
                    Name = "Saudi Arabia",
                    IsoAlfa2Code = "SA",
                    IsoAlfa3Code = "SAU",
                    IsoNumericCode = 682
                },
                new Country()
                {
                    Id = 198,
                    Name = "Senegal",
                    IsoAlfa2Code = "SN",
                    IsoAlfa3Code = "SEN",
                    IsoNumericCode = 686
                },
                new Country()
                {
                    Id = 199,
                    Name = "Serbia",
                    IsoAlfa2Code = "RS",
                    IsoAlfa3Code = "SRB",
                    IsoNumericCode = 688
                },
                new Country()
                {
                    Id = 200,
                    Name = "Seychelles",
                    IsoAlfa2Code = "SC",
                    IsoAlfa3Code = "SYC",
                    IsoNumericCode = 690
                },
                new Country()
                {
                    Id = 201,
                    Name = "Sierra Leone",
                    IsoAlfa2Code = "SL",
                    IsoAlfa3Code = "SLE",
                    IsoNumericCode = 694
                },
                new Country()
                {
                    Id = 202,
                    Name = "Singapore",
                    IsoAlfa2Code = "SG",
                    IsoAlfa3Code = "SGP",
                    IsoNumericCode = 702
                },
                new Country()
                {
                    Id = 203,
                    Name = "Slovakia",
                    IsoAlfa2Code = "SK",
                    IsoAlfa3Code = "SVK",
                    IsoNumericCode = 703
                },
                new Country()
                {
                    Id = 204,
                    Name = "Viet Nam",
                    IsoAlfa2Code = "VN",
                    IsoAlfa3Code = "VNM",
                    IsoNumericCode = 704
                },
                new Country()
                {
                    Id = 205,
                    Name = "Slovenia",
                    IsoAlfa2Code = "SI",
                    IsoAlfa3Code = "SVN",
                    IsoNumericCode = 705
                },
                new Country()
                {
                    Id = 206,
                    Name = "Somalia",
                    IsoAlfa2Code = "SO",
                    IsoAlfa3Code = "SOM",
                    IsoNumericCode = 706
                },
                new Country()
                {
                    Id = 207,
                    Name = "South Africa",
                    IsoAlfa2Code = "ZA",
                    IsoAlfa3Code = "ZAF",
                    IsoNumericCode = 710
                },
                new Country()
                {
                    Id = 208,
                    Name = "Zimbabwe",
                    IsoAlfa2Code = "ZW",
                    IsoAlfa3Code = "ZWE",
                    IsoNumericCode = 716
                },
                new Country()
                {
                    Id = 209,
                    Name = "Spain",
                    IsoAlfa2Code = "ES",
                    IsoAlfa3Code = "ESP",
                    IsoNumericCode = 724
                },
                new Country()
                {
                    Id = 210,
                    Name = "South Sudan",
                    IsoAlfa2Code = "SS",
                    IsoAlfa3Code = "SSD",
                    IsoNumericCode = 728
                },
                new Country()
                {
                    Id = 211,
                    Name = "Sudan (the)",
                    IsoAlfa2Code = "SD",
                    IsoAlfa3Code = "SDN",
                    IsoNumericCode = 729
                },
                new Country()
                {
                    Id = 212,
                    Name = "Western Sahara*",
                    IsoAlfa2Code = "EH",
                    IsoAlfa3Code = "ESH",
                    IsoNumericCode = 732
                },
                new Country()
                {
                    Id = 213,
                    Name = "Suriname",
                    IsoAlfa2Code = "SR",
                    IsoAlfa3Code = "SUR",
                    IsoNumericCode = 740
                },
                new Country()
                {
                    Id = 214,
                    Name = "Svalbard and Jan Mayen",
                    IsoAlfa2Code = "SJ",
                    IsoAlfa3Code = "SJM",
                    IsoNumericCode = 744
                },
                new Country()
                {
                    Id = 215,
                    Name = "Eswatini",
                    IsoAlfa2Code = "SZ",
                    IsoAlfa3Code = "SWZ",
                    IsoNumericCode = 748
                },
                new Country()
                {
                    Id = 216,
                    Name = "Sweden",
                    IsoAlfa2Code = "SE",
                    IsoAlfa3Code = "SWE",
                    IsoNumericCode = 752
                },
                new Country()
                {
                    Id = 217,
                    Name = "Switzerland",
                    IsoAlfa2Code = "CH",
                    IsoAlfa3Code = "CHE",
                    IsoNumericCode = 756
                },
                new Country()
                {
                    Id = 218,
                    Name = "Syrian Arab Republic (the)",
                    IsoAlfa2Code = "SY",
                    IsoAlfa3Code = "SYR",
                    IsoNumericCode = 760
                },
                new Country()
                {
                    Id = 219,
                    Name = "Tajikistan",
                    IsoAlfa2Code = "TJ",
                    IsoAlfa3Code = "TJK",
                    IsoNumericCode = 762
                },
                new Country()
                {
                    Id = 220,
                    Name = "Thailand",
                    IsoAlfa2Code = "TH",
                    IsoAlfa3Code = "THA",
                    IsoNumericCode = 764
                },
                new Country()
                {
                    Id = 221,
                    Name = "Togo",
                    IsoAlfa2Code = "TG",
                    IsoAlfa3Code = "TGO",
                    IsoNumericCode = 768
                },
                new Country()
                {
                    Id = 222,
                    Name = "Tokelau",
                    IsoAlfa2Code = "TK",
                    IsoAlfa3Code = "TKL",
                    IsoNumericCode = 772
                },
                new Country()
                {
                    Id = 223,
                    Name = "Tonga",
                    IsoAlfa2Code = "TO",
                    IsoAlfa3Code = "TON",
                    IsoNumericCode = 776
                },
                new Country()
                {
                    Id = 224,
                    Name = "Trinidad and Tobago",
                    IsoAlfa2Code = "TT",
                    IsoAlfa3Code = "TTO",
                    IsoNumericCode = 780
                },
                new Country()
                {
                    Id = 225,
                    Name = "United Arab Emirates (the)",
                    IsoAlfa2Code = "AE",
                    IsoAlfa3Code = "ARE",
                    IsoNumericCode = 784
                },
                new Country()
                {
                    Id = 226,
                    Name = "Tunisia",
                    IsoAlfa2Code = "TN",
                    IsoAlfa3Code = "TUN",
                    IsoNumericCode = 788
                },
                new Country()
                {
                    Id = 227,
                    Name = "Türkiye",
                    IsoAlfa2Code = "TR",
                    IsoAlfa3Code = "TUR",
                    IsoNumericCode = 792
                },
                new Country()
                {
                    Id = 228,
                    Name = "Turkmenistan",
                    IsoAlfa2Code = "TM",
                    IsoAlfa3Code = "TKM",
                    IsoNumericCode = 795
                },
                new Country()
                {
                    Id = 229,
                    Name = "Turks and Caicos Islands (the)",
                    IsoAlfa2Code = "TC",
                    IsoAlfa3Code = "TCA",
                    IsoNumericCode = 796
                },
                new Country()
                {
                    Id = 230,
                    Name = "Tuvalu",
                    IsoAlfa2Code = "TV",
                    IsoAlfa3Code = "TUV",
                    IsoNumericCode = 798
                },
                new Country()
                {
                    Id = 231,
                    Name = "Uganda",
                    IsoAlfa2Code = "UG",
                    IsoAlfa3Code = "UGA",
                    IsoNumericCode = 800
                },
                new Country()
                {
                    Id = 232,
                    Name = "Ukraine",
                    IsoAlfa2Code = "UA",
                    IsoAlfa3Code = "UKR",
                    IsoNumericCode = 804
                },
                new Country()
                {
                    Id = 233,
                    Name = "North Macedonia",
                    IsoAlfa2Code = "MK",
                    IsoAlfa3Code = "MKD",
                    IsoNumericCode = 807
                },
                new Country()
                {
                    Id = 234,
                    Name = "Egypt",
                    IsoAlfa2Code = "EG",
                    IsoAlfa3Code = "EGY",
                    IsoNumericCode = 818
                },
                new Country()
                {
                    Id = 235,
                    Name = "United Kingdom of Great Britain and Northern Ireland (the)",
                    IsoAlfa2Code = "GB",
                    IsoAlfa3Code = "GBR",
                    IsoNumericCode = 826
                },
                new Country()
                {
                    Id = 236,
                    Name = "Guernsey",
                    IsoAlfa2Code = "GG",
                    IsoAlfa3Code = "GGY",
                    IsoNumericCode = 831
                },
                new Country()
                {
                    Id = 237,
                    Name = "Jersey",
                    IsoAlfa2Code = "JE",
                    IsoAlfa3Code = "JEY",
                    IsoNumericCode = 832
                },
                new Country()
                {
                    Id = 238,
                    Name = "Isle of Man",
                    IsoAlfa2Code = "IM",
                    IsoAlfa3Code = "IMN",
                    IsoNumericCode = 833
                },
                new Country()
                {
                    Id = 239,
                    Name = "Tanzania, the United Republic of",
                    IsoAlfa2Code = "TZ",
                    IsoAlfa3Code = "TZA",
                    IsoNumericCode = 834
                },
                new Country()
                {
                    Id = 240,
                    Name = "United States of America (the)",
                    IsoAlfa2Code = "US",
                    IsoAlfa3Code = "USA",
                    IsoNumericCode = 840
                },
                new Country()
                {
                    Id = 241,
                    Name = "Virgin Islands (U.S.)",
                    IsoAlfa2Code = "VI",
                    IsoAlfa3Code = "VIR",
                    IsoNumericCode = 850
                },
                new Country()
                {
                    Id = 242,
                    Name = "Burkina Faso",
                    IsoAlfa2Code = "BF",
                    IsoAlfa3Code = "BFA",
                    IsoNumericCode = 854
                },
                new Country()
                {
                    Id = 243,
                    Name = "Uruguay",
                    IsoAlfa2Code = "UY",
                    IsoAlfa3Code = "URY",
                    IsoNumericCode = 858
                },
                new Country()
                {
                    Id = 244,
                    Name = "Uzbekistan",
                    IsoAlfa2Code = "UZ",
                    IsoAlfa3Code = "UZB",
                    IsoNumericCode = 860
                },
                new Country()
                {
                    Id = 245,
                    Name = "Venezuela (Bolivarian Republic of)",
                    IsoAlfa2Code = "VE",
                    IsoAlfa3Code = "VEN",
                    IsoNumericCode = 862
                },
                new Country()
                {
                    Id = 246,
                    Name = "Wallis and Futuna",
                    IsoAlfa2Code = "WF",
                    IsoAlfa3Code = "WLF",
                    IsoNumericCode = 876
                },
                new Country()
                {
                    Id = 247,
                    Name = "Samoa",
                    IsoAlfa2Code = "WS",
                    IsoAlfa3Code = "WSM",
                    IsoNumericCode = 882
                },
                new Country()
                {
                    Id = 248,
                    Name = "Yemen",
                    IsoAlfa2Code = "YE",
                    IsoAlfa3Code = "YEM",
                    IsoNumericCode = 887
                },
                new Country()
                {
                    Id = 249,
                    Name = "Zambia",
                    IsoAlfa2Code = "ZM",
                    IsoAlfa3Code = "ZMB",
                    IsoNumericCode = 894
                }
            };

            return entityData;
        }
    }
}
