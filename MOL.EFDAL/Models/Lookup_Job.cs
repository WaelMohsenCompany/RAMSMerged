using System;
using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    public class Lookup_Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsForSaudiOnly { get; set; }
        public string JobCode { get; set; }
        public bool? IsIncludedForEWV { get; set; }
        public string QsimCode { get; set; }
        public string JzaCode { get; set; }
        public string BabCode { get; set; }
        public string FslCode { get; set; }
        public string MhnCode { get; set; }
        public string MstCode { get; set; }
        public bool? CanChangeOnline { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsValidWPJob { get; set; }
        public bool isGovSupportEWV { get; set; }
        public bool IsGenderRequired { get; set; }
        
        public bool? IsEngineeringJob { get; set; }
        public bool IsValid1_5ForIstiqdam { get; set; }
        public bool IsHomeJob { get; set; }

        public bool IsBlockedForSeasonalVisas { get; set; }

        public bool IsMedicalJob { get; set; }

        public virtual ICollection<MOL_EstablishmentVisaCreditJobsHistory> MOL_EstablishmentVisaCreditJobsHistory { get; set; } = new List<MOL_EstablishmentVisaCreditJobsHistory>();
        public virtual ICollection<MOL_EstablishmentVisaCreditJobs> MOL_EstablishmentVisaCreditJobs { get; set; } = new List<MOL_EstablishmentVisaCreditJobs>();
    }
}
