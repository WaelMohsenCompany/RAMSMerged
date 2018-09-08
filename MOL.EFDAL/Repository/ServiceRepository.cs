using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    public class ServiceRepository
    {
        public static Enum_Service GetServiceById(int serviceId)
        {
            using (var context = new MOL.EFDAL.MOLEFEntities())
            {
                return context.Enum_Service.Single(x => x.Id == serviceId);
            }
        }
    }
}
