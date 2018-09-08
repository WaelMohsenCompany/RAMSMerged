using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    public partial class Program_Status_Repository : EFRepository<Program_Status>
    {
        public Program_Status_Repository()
        {

        }

        public Program_Status_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}

