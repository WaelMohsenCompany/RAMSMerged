using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    public partial class Joining_Rule
    {
        public Joining_Rule()
        {
            this.Joining_Rules_Validation_Log = new List<Joining_Rules_Validation_Log>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Joining_Rules_Validation_Log> Joining_Rules_Validation_Log { get; set; }
    }
}
