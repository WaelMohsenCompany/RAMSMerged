using MOL.EFDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class Lookup_Job_Repository : EFRepository<Lookup_Job>
    {
        /// <summary>
        /// Gets list of home jobs.
        /// </summary>
        public List<Lookup_Job> GetHomeJobs()
        {
            return this.Where(s => s.IsHomeJob).ToList();
        }
    }
}
