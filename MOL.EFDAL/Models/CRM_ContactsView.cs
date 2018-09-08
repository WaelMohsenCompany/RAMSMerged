namespace MOL.EFDAL.Models
{
    using System;

    public partial class CRM_ContactsView
    {
        public int Id { get; set; }
        public string NationalId { get; set; }
        public Nullable<long> PK_EstablishmentId { get; set; }
        public Nullable<int> FK_LaborOfficeId { get; set; }
        public Nullable<long> SequenceNumber { get; set; }
        public string EstablishmentName { get; set; }
        public Nullable<int> ContactTypeId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public string Nationality { get; set; }
        public string NationalIdSource { get; set; }
        public string ContactType { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
