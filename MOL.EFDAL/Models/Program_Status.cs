using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    public partial class Program_Status
    {
        public Program_Status()
        {
            this.Program_Establishment = new List<Program_Establishment>();
            this.Program_Establishment_History = new List<Program_Establishment_History>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Program_Establishment> Program_Establishment { get; set; }
        public virtual ICollection<Program_Establishment_History> Program_Establishment_History { get; set; }
    }
}
