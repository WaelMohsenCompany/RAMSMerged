namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_LaborOffice
    {
        public MOL_LaborOffice()
        {
        }

		[DataMember]
        public int PK_LaborOfficeId { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public short? FK_BankId { get; set; }
		[DataMember]
        public long? AccountNumber { get; set; }
		[DataMember]
        public double? Balance { get; set; }
		[DataMember]
        public int? FK_CityId { get; set; }
		[DataMember]
        public string District { get; set; }
		[DataMember]
        public string Street { get; set; }
		[DataMember]
        public string PostalCode { get; set; }
		[DataMember]
        public string ZipCode { get; set; }
		[DataMember]
        public string Telephone1 { get; set; }
		[DataMember]
        public string Telephone2 { get; set; }
		[DataMember]
        public string Fax { get; set; }
		[DataMember]
        public string ManagerName { get; set; }
		[DataMember]
        public bool? IsActive { get; set; }
		[DataMember]
        public short? FK_ZoneId { get; set; }
		[DataMember]
        public string BenChapterNo { get; set; }
		[DataMember]
        public string BenBranchNo { get; set; }
		[DataMember]
        public string BenSectionNo { get; set; }
		[DataMember]
        public string BenSequenceNo { get; set; }
		[DataMember]
        public string BenSubDepartmentsCount { get; set; }
		[DataMember]
        public string BenSubSectionsCount { get; set; }
		[DataMember]
        public string DepChapterNo { get; set; }
		[DataMember]
        public string DepBranchNo { get; set; }
		[DataMember]
        public string DepSectionNo { get; set; }
		[DataMember]
        public string DepSequenceNo { get; set; }
		[DataMember]
        public string DepSubDepartmentsCount { get; set; }
		[DataMember]
        public string DepSubSectionsCount { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public virtual Lookup_Bank Lookup_Bank { get; set; }
		[DataMember]
        public virtual Lookup_City Lookup_City { get; set; }
		[DataMember]
        public virtual ICollection<Lookup_Municipality> Lookup_Municipality { get; set; } = new List<Lookup_Municipality>();

	    [DataMember]
        public virtual Lookup_Zone Lookup_Zone { get; set; }
		[DataMember]
        public virtual ICollection<MOL_Agent> MOL_Agent { get; set; } = new List<MOL_Agent>();

	    [DataMember]
        public virtual ICollection<MOL_Laborer> MOL_Laborer { get; set; } = new List<MOL_Laborer>();

	    [DataMember]
        public virtual ICollection<MOL_Laborer> MOL_Laborer1 { get; set; } = new List<MOL_Laborer>();

	    [DataMember]
        public virtual ICollection<MOL_Owner> MOL_Owner { get; set; } = new List<MOL_Owner>();

	    [DataMember]
        public virtual ICollection<MOL_Srv_Transaction> MOL_Srv_Transaction { get; set; } = new List<MOL_Srv_Transaction>();

	    [DataMember]
        public virtual ICollection<MOL_TransferRequest> MOL_TransferRequest { get; set; } = new List<MOL_TransferRequest>();

	    [DataMember]
        public virtual ICollection<MOL_TransferRequest> MOL_TransferRequest1 { get; set; } = new List<MOL_TransferRequest>();

	    [DataMember]
        public virtual ICollection<MOL_UnifiedNumber> MOL_UnifiedNumber { get; set; } = new List<MOL_UnifiedNumber>();

	    [DataMember]
        public virtual ICollection<MOL_User> MOL_User { get; set; } = new List<MOL_User>();
    }
}
