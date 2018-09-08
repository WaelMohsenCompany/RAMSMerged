namespace MOL.EFDAL.Repository
{
    using MOL.EFDAL.Models;

    public partial class Vw_UNPaidExtraFeesUnites_Repository : EFRepository<Vw_UNPaidExtraFeesUnites>
    {
        public Vw_UNPaidExtraFeesUnites_Repository()
        {

        }

        public Vw_UNPaidExtraFeesUnites_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}