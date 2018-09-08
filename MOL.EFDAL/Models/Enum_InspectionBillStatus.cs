namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Enum_InspectionBillStatus
    {
        public Enum_InspectionBillStatus()
        {
        }

		[DataMember]
        public int PK_BillStatusCode { get; set; }
		[DataMember]
        public string BillStatusDescription { get; set; }
    }
}
