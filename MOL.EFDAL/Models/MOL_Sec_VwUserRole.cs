namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_Sec_VwUserRole
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
        public long MOL_Sec_Role_Id { get; set; }
		[DataMember]
        public string RoleName { get; set; }
		[DataMember]
        public string Local_Name { get; set; }
		[DataMember]
        public long UserRole_User_Id { get; set; }
		[DataMember]
        public long UserRole_Role_Id { get; set; }
    }
}
