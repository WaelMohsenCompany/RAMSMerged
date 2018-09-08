namespace MOL.EFDAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Lookup_EconomicActivity
    {
        public Lookup_EconomicActivity()
        {
        }

        public int PK_EconomicActivityId { get; set; }
        public string ActivityName { get; set; }
        public int? FK_MainEconomicActivityId { get; set; }
        public float SaudizationPercentage { get; set; }
        public bool IsSocialInsuranceLicenseFree { get; set; }
        public bool IsZakatLicenseFree { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsEligibleForIstiqdamImmediateApprove { get; set; }
        public bool? Financial_Nitaqat_Enabled { get; set; }

        public virtual ICollection<Lookup_EconomicActivity> Lookup_EconomicActivity1 { get; set; } = new HashSet<Lookup_EconomicActivity>();
        public virtual Lookup_EconomicActivity Lookup_EconomicActivity2 { get; set; }
        public virtual ICollection<MOL_Establishment> MOL_Establishment { get; set; } = new HashSet<MOL_Establishment>();

        public virtual ICollection<MOL_EconomicActivity_Jobs_Gender> MOL_EconomicActivity_Jobs_Gender { get; set; } = new HashSet<MOL_EconomicActivity_Jobs_Gender>();
    }
}
