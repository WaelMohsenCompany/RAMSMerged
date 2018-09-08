namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class MOL_VisaBalanceRejectReason
    {
        public MOL_VisaBalanceRejectReason()
        {
        }

		[DataMember]
        public int Id { get; set; }
		[DataMember]
        public string ReasonDescription { get; set; }
    }
}
