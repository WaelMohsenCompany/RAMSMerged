namespace MOL.EFDAL.Models
{
    using System.Runtime.Serialization;


    [DataContract]
    public partial class MOL_CEAUserService
    {
		[DataMember]
        public long Pk_CEAUserServiceId { get; set; }
		[DataMember]
        public long Fk_UserId { get; set; }
		[DataMember]
        public bool IsActive { get; set; }
		[DataMember]
        public virtual MOL_User MOL_User { get; set; }
    }
}
