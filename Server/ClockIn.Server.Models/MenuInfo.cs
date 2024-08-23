using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClockIn.Server.Models
{
    [Table("menus")]
    public class MenuInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("menu_id")]
        public int MenuId { get; set; }

        [Column("menu_header")]
        public string MenuHeader { get; set; }

        [Column("target_view")]
        public string targetView { get; set; }

        [Column("menu_icon",TypeName="varchar(64)")]
        public string MenuIcon { get; set; }

        [Column("index")]
        public int Index { get; set; }

        [Column("menu_type")]
        public bool MenuType { get; set; }

        [Column("state")]
        [DefaultValue(1)]
        public int State { get; set; }
    }
}
