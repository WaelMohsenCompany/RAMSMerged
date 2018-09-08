using MOL.EFDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MOL.EFDAL.Repository
{

    public partial class VwManpowerMenu_Repository : EFRepository<VwManpowerMenu>
    {
        public VwManpowerMenu_Repository(MOLEFEntities context) : base(context)
        {

        }

        public List<MenuItems> GetMenuItems(List<long> privilegeList)
        {
            List<MenuItems> menu = new List<MenuItems>();

            var Groups = this.Where(w => w.SectionID == 1 && w.IsActive == true && privilegeList.Contains(w.PrivilegeID)).ToList().OrderBy(o => o.GroupOrder).GroupBy(g => g.GroupID);

            foreach (var group in Groups)
            {
                MenuItems item = new MenuItems
                {
                    ID = group.ToList()[0].GroupID,
                    Name = group.ToList()[0].GroupName,
                    Order = group.ToList()[0].GroupOrder.Value,
                    SubItems = new List<MenuItems>()
                };



                foreach (var securableEntityType in group.ToList().GroupBy(g => g.SecurableEntityTypeID))
                {

                    MenuItems securableEntityTypeItem = new MenuItems
                    {
                        ID = securableEntityType.ToList()[0].SecurableEntityTypeID,
                        Name = securableEntityType.ToList()[0].SecurableEntityTypeName,
                        Order = securableEntityType.ToList()[0].SecurableEntityTypeOrder,
                        SubItems = new List<MenuItems>()
                    };

                    foreach (var manpowerMenu in securableEntityType)
                    {
                        securableEntityTypeItem.SubItems.Add(new MenuItems
                        {
                            ID = manpowerMenu.PrivilegeID,
                            Name = manpowerMenu.PrivilegeName,
                            Order = manpowerMenu.PrivilegeOrder,
                            URL = manpowerMenu.URL,
                        });
                    }

                    item.SubItems.Add(securableEntityTypeItem);
                }

                menu.Add(item);
            }

            return menu;
        }
    }

    public class MenuItems
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string URL { get; set; }

        public List<MenuItems> SubItems { get; set; }
    }
}


