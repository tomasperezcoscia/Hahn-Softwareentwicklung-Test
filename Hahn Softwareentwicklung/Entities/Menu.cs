using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hahn_Softwareentwicklung.Entities
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public Menu() { }
        public Menu(string name, string icon, string url)
        {
            Name = name;
            Icon = icon;
            Url = url;
        }
    }
}
