namespace CustomerSupportSystem.Infrastructure.Constants
{
    public static class DataTypesConstants
    {
        //File
        public const int FileNameMinLenght = 6;
        public const int FileNameMaxLenght = 250;
        public const int FileExtensionMaxLenght = 4;

        //TicketType
        public const int TicketTypeTitleMaxLenght = 20;

        //TicketStatus
        public const int TicketStatusTitleMaxLenght = 20;

        //TicketPriority
        public const int TicketPriorityTitleMaxLenght = 20;

        //Ticket
        public const int TicketSubjectMinLenght = 10;
        public const int TicketSubjectMaxLenght = 250;

        //TicketPost
        public const int TicketPostTextMinLenght = 10;
        public const int TicketPostTextMaxLenght = 4000;

        //Country
        public const int CountryNameMaxLenght = 100;
        public const int IsoAlfa2CodeMaxLenght = 2;
        public const int IsoAlfa3CodeMaxLenght = 3;

        //Partner
        public const int PartnerNameMinLenght = 4;
        public const int PartnerNameMaxLenght = 100;
        public const int AddressMinLenght = 10;
        public const int AddressMaxLenght = 100;
        public const int CityMaxLenght = 200;
        public const int PostcodeMaxLenght = 20;
        public const int PartnerRegistrationNumberMinLenght = 5;
        public const int PartnerRegistrationNumberMaxLenght = 50;
        public const int PartnerTaxNumberMinLenght = 5;
        public const int PartnerTaxNumberMaxLenght = 50;
        public const int WebsiteMaxLenght = 50;
        public const int SubscriptionContractNumberMaxLenght = 50;

        //JobTitle
        public const int JobTitleMaxLenght = 50;

        //Person
        public const int PersonFirstNameMaxLenght = 50;
        public const int PersonLastNameMaxLenght = 50;

        //Email
        public const int EmailAddressMaxLenght = 260;
        public const string EmailAddressRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        //PhoneNumber
        public const int PhoneNumberMaxLenght = 20;
        public const string PhoneNumberRegex = @"^(\+\d{1,3}\s?)?((\(\d{3}\)\s?)|(\d{3})(\s|-?))(\d{3}(\s|-?))(\d{4})(\s?(([E|e]xt[:|.|]?)|x|X)(\s?\d+))?$";

    }
}
