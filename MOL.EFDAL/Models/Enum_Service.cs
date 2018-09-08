namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_Service
    {
        public Enum_Service()
        {
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int? AuthorizationLevel { get; set; }
        [DataMember]
        public System.DateTime? CreatedOn { get; set; }
        [DataMember]
        public System.DateTime? ModifiedOn { get; set; }
        [DataMember]
        public int? IsWASALRequired { get; set; }
        [DataMember]
        public bool? IsGosiStoppedService { get; set; }
        [DataMember]
        public short? FK_ServiceCategoryId { get; set; }
        [DataMember]
        public bool? ValidateLicensesMatrix { get; set; }


        [DataMember]
        public virtual ICollection<MOL_EstablishmentAgentService> MOL_EstablishmentAgentService { get; set; } = new List<MOL_EstablishmentAgentService>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentCommissionerService> MOL_EstablishmentCommissionerService { get; set; } = new List<MOL_EstablishmentCommissionerService>();

        [DataMember]
        public virtual ICollection<MOL_EstablishmentNoteService> MOL_EstablishmentNoteService { get; set; } = new List<MOL_EstablishmentNoteService>();

        [DataMember]
        public virtual ICollection<MOL_OracleTransactionLog> MOL_OracleTransactionLog { get; set; } = new List<MOL_OracleTransactionLog>();

        [DataMember]
        public virtual ICollection<MOL_Srv_Transaction> MOL_Srv_Transaction { get; set; } = new List<MOL_Srv_Transaction>();

        [DataMember]
        public virtual ICollection<MOL_Sec_Privilege> MOL_Sec_Privilege { get; set; } = new List<MOL_Sec_Privilege>();
    }
}
