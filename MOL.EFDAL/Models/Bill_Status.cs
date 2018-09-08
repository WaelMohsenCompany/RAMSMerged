using System.Collections.Generic;

namespace MOL.EFDAL.Models
{
    public partial class Bill_Status
    {
        public Bill_Status()
        {
            this.Periodic_Bill = new List<Periodic_Bill>();
            this.Periodic_Bill_History = new List<Periodic_Bill_History>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Periodic_Bill> Periodic_Bill { get; set; }
        public virtual ICollection<Periodic_Bill_History> Periodic_Bill_History { get; set; }
    }
}
