using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    public partial class Program_Establishment_Repository : EFRepository<Program_Establishment>
    {
        public Program_Establishment_Repository()
        {

        }

        public Program_Establishment_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}

