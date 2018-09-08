namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VwChangeEstablishmentActivityApprovalUsers
    {
		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public string UserName { get; set; }
		[DataMember]
        public string Password { get; set; }
		[DataMember]
        public string First_Name { get; set; }
		[DataMember]
        public string Second_Name { get; set; }
		[DataMember]
        public string Third_Name { get; set; }
		[DataMember]
        public string Fourth_Name { get; set; }
		[DataMember]
        public short? Nationality { get; set; }
		[DataMember]
        public System.DateTime? Birth_Date { get; set; }
		[DataMember]
        public int? User_Type_Id { get; set; }
		[DataMember]
        public int? UserId { get; set; }
		[DataMember]
        public string Email { get; set; }
		[DataMember]
        public System.DateTime? LastLoggedIn { get; set; }
		[DataMember]
        public int? FK_LaborOfficeId { get; set; }
		[DataMember]
        public int? GenderID { get; set; }
		[DataMember]
        public int? MaritalStatusID { get; set; }
		[DataMember]
        public long? Id_Number { get; set; }
		[DataMember]
        public System.DateTime? Id_ExpiryDate { get; set; }
		[DataMember]
        public long? Iqama_Number { get; set; }
		[DataMember]
        public System.DateTime? Iqama_ExpiryDate { get; set; }
		[DataMember]
        public int? EmailLangID { get; set; }
		[DataMember]
        public bool? IsUserDeleted { get; set; }
		[DataMember]
        public string PlaceofBirth { get; set; }
		[DataMember]
        public bool? IsActivated { get; set; }
		[DataMember]
        public string MobileNumber { get; set; }
		[DataMember]
        public bool IsSystem { get; set; }
		[DataMember]
        public string TwitterAccount { get; set; }
		[DataMember]
        public string POBox { get; set; }
		[DataMember]
        public string ZipCode { get; set; }
		[DataMember]
        public string Fax { get; set; }
		[DataMember]
        public System.DateTime? Created { get; set; }
		[DataMember]
        public bool? FromHafiz { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public long? CreatedBy { get; set; }
		[DataMember]
        public bool IsEmailVerified { get; set; }
		[DataMember]
        public short EmailVerificationCount { get; set; }
		[DataMember]
        public System.DateTime? EmailLastVerificationDate { get; set; }
		[DataMember]
        public bool IsMobileVerified { get; set; }
		[DataMember]
        public short MobileVerificationCount { get; set; }
		[DataMember]
        public System.DateTime? MobileLastVerificationDate { get; set; }
		[DataMember]
        public bool IsDataVerified { get; set; }
    }
}
