namespace MOL.EFDAL
{
    using System;

    public class SP_CUST_MOL_Sec_Privilege_GetAuthorizedUserServices_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? AuthorizationLevel { get; set; }
        public int? IsWASALRequired { get; set; }
        public bool? IsGosiStoppedService { get; set; }
        public short? FK_ServiceCategoryId { get; set; }
        public long Privilege_Id { get; set; }
    }
}