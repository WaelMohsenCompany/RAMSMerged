namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Lookup_Nationality
    {
        public Lookup_Nationality()
        {
        }

		[DataMember]
        public short Id { get; set; }
		[DataMember]
        public string Name { get; set; }
		[DataMember]
        public string Name_EN { get; set; }
		[DataMember]
        public bool? IsIncludedForEWV { get; set; }
		[DataMember]
        public System.DateTime? CreatedOn { get; set; }
		[DataMember]
        public System.DateTime? ModifiedOn { get; set; }
		[DataMember]
        public bool? IsBanForFollowerTransfer { get; set; }
		[DataMember]
        public int? NIC_CountryCode { get; set; }
		[DataMember]
        public bool AllowedForAccountManager { get; set; }
		[DataMember]
        public virtual ICollection<Lookup_Origins> Lookup_Origins { get; set; } = new List<Lookup_Origins>();
	    [DataMember]
        public virtual ICollection<MOL_AccountManager> MOL_AccountManager { get; set; } = new List<MOL_AccountManager>();
	    [DataMember]
        public virtual ICollection<MOL_Laborer> MOL_Laborer { get; set; } = new List<MOL_Laborer>();
	    [DataMember]
        public virtual ICollection<MOL_Owner> MOL_Owner { get; set; } = new List<MOL_Owner>();
	    [DataMember]
        public virtual ICollection<MOL_UnifiedNumber> MOL_UnifiedNumber { get; set; } = new List<MOL_UnifiedNumber>();
	    [DataMember]
        public virtual ICollection<MOL_User> MOL_User { get; set; } = new List<MOL_User>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentMCIParties> MOL_EstablishmentMCIParties { get; set; } = new List<MOL_EstablishmentMCIParties>();
    }
}
