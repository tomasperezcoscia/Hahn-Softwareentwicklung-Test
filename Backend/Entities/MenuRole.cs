using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn_Softwareentwicklung.Entities
{
    public class MenuRole
    {
        public int Id { get; set; }
        [ForeignKey("Menu")]
        public int menuId { get; set; }
        [ForeignKey("Role")]
        public int roleId { get; set; }


        public MenuRole() { }
        public MenuRole(int menuId, int roleId)
        {
            this.menuId = menuId;
            this.roleId = roleId;
        }

    }
}
