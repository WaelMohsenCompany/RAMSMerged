namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwAccountManager
    {
		[DataMember]
        public string AccountManagerTypeName { get; set; }
		[DataMember]
        public int UN_LaborOffice { get; set; }
		[DataMember]
        public long UN_SequenceNumber { get; set; }
		[DataMember]
        public long PK_AccountManagerID { get; set; }
		[DataMember]
        public long? FK_UserID { get; set; }
		[DataMember]
        public long IDNO { get; set; }
		[DataMember]
        public string FirstName { get; set; }
		[DataMember]
        public string SecondName { get; set; }
		[DataMember]
        public string ThirdName { get; set; }
		[DataMember]
        public string FourthName { get; set; }
		[DataMember]
        public string FullName { get; set; }
		[DataMember]
        public System.DateTime BirthDate { get; set; }
		[DataMember]
        public short FK_NationalityID { get; set; }
		[DataMember]
        public long FK_UnifiedNumberId { get; set; }
		[DataMember]
        public int FK_AccountManagerTypeId { get; set; }
		[DataMember]
        public System.Guid FK_AttachmentID { get; set; }
		[DataMember]
        public long? User_Id { get; set; }
		[DataMember]
        public long Role_Id { get; set; }
		[DataMember]
        public bool? IsStopRole { get; set; }
		[DataMember]
        public System.DateTime? StartDate { get; set; }
		[DataMember]
        public System.DateTime? EndDate { get; set; }
		[DataMember]
        public long? FK_SecurableEntityId { get; set; }
		[DataMember]
        public string Email { get; set; }
		[DataMember]
        public System.DateTime? Id_ExpiryDate { get; set; }
		[DataMember]
        public System.DateTime? Iqama_ExpiryDate { get; set; }
		[DataMember]
        public string POBox { get; set; }
		[DataMember]
        public string ZipCode { get; set; }
		[DataMember]
        public string Fax { get; set; }
		[DataMember]
        public bool? IsEmailVerified { get; set; }
		[DataMember]
        public short? EmailVerificationCount { get; set; }
		[DataMember]
        public System.DateTime? EmailLastVerificationDate { get; set; }
		[DataMember]
        public bool? IsMobileVerified { get; set; }
		[DataMember]
        public short? MobileVerificationCount { get; set; }
		[DataMember]
        public System.DateTime? MobileLastVerificationDate { get; set; }
		[DataMember]
        public bool? IsDataVerified { get; set; }
    }
}
