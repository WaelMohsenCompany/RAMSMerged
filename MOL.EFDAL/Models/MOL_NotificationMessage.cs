namespace MOL.EFDAL.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_NotificationMessage
    {
        public MOL_NotificationMessage()
        {
        }

		[DataMember]
        public long Id { get; set; }
		[DataMember]
        public string EmailTxt { get; set; }
		[DataMember]
        public string SmsTxt { get; set; }
		[DataMember]
        public string UserInterfaceTxt { get; set; }
		[DataMember]
        public int FK_NotificationMessageCreatorId { get; set; }
		[DataMember]
        public int? FK_StatusId { get; set; }
		[DataMember]
        public bool? IsSentSuccessfully { get; set; }
		[DataMember]
        public System.DateTime? SendAttemptDate { get; set; }
		[DataMember]
        public int? SendAttemptCount { get; set; }
		[DataMember]
        public long FK_EstablishmentID { get; set; }
		[DataMember]
        public bool? IgnoreIfNotSent { get; set; }
		[DataMember]
        public long? FK_LaborerID { get; set; }
		[DataMember]
        public string LaborerIdNo { get; set; }
		[DataMember]
        public string LaborerFullName { get; set; }
		[DataMember]
        public System.DateTime? OperationDate { get; set; }
		[DataMember]
        public System.DateTime? ShownDate { get; set; }
		[DataMember]
        public int? Agent_EstablishmentAgentId { get; set; }
		[DataMember]
        public System.DateTime? Agent_AgencyEndDate { get; set; }
		[DataMember]
        public int? Commissioner_EstablishmentCommissionerId { get; set; }
		[DataMember]
        public System.DateTime? Comissioner_CommisionEndDate { get; set; }
		[DataMember]
        public System.DateTime? EstablishmentLicenseExpirationDate { get; set; }
		[DataMember]
        public string EstablishmentLicenseNumber { get; set; }
		[DataMember]
        public bool? IsWarning { get; set; }
		[DataMember]
        public virtual Enum_NotificationMessageCreator Enum_NotificationMessageCreator { get; set; }
		[DataMember]
        public virtual Enum_NotificationMessageStatus Enum_NotificationMessageStatus { get; set; }
		[DataMember]
        public virtual MOL_Establishment MOL_Establishment { get; set; }
		[DataMember]
        public virtual ICollection<MOL_NotificationMessageReceiver> MOL_NotificationMessageReceiver { get; set; } = new List<MOL_NotificationMessageReceiver>();
    }
}
