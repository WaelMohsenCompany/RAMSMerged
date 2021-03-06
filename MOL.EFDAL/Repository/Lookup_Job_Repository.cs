//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public partial class Lookup_Job_Repository : EFRepository<Lookup_Job>
    {
        public Lookup_Job_Repository()
        {
            Context = new MOLEFEntities();
        }

        public Lookup_Job_Repository(MOLEFEntities context) : base(context)
        {

        }

        public bool IsMedicalJob(int jobId)
        {
            return Where(w => w.Id == jobId && w.IsMedicalJob).Any();
        }
    }
}

