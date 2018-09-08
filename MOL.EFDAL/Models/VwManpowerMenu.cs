namespace MOL.EFDAL.Models
{
    public partial class VwManpowerMenu
    {
        public int? SectionID { get; set; }
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int? GroupOrder { get; set; }
        public long SecurableEntityTypeID { get; set; }
        public string SecurableEntityTypeName { get; set; }
        public int SecurableEntityTypeOrder { get; set; }
        public string URL { get; set; }
        public bool IsActive { get; set; }
        public long PrivilegeID { get; set; }
        public string PrivilegeName { get; set; }
        public int PrivilegeOrder { get; set; }
    }
}
