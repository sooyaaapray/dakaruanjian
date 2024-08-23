using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClockIn.Server.Models
{
    [Table("sys_user_info")]
    public class SysUserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int user_id { get; set; }

        [Column("user_name")]
        public string user_name { get; set; }

        [Column("user_role")]
        public string user_role { get; set; }

        [Column("user_ip_address")]
        public string user_ip_address { get; set; }

        [Column("user_mac")]
        public string user_mac { get; set; }

        [Column("user_pwd")]
        public string user_pwd { get; set; }

        [Column("user_login_name")]
        public string user_login_name { get; set; }

        [Column("is_admin")]
        public bool is_admin { get; set; }

        [Column("is_active")]
        public bool is_active { get; set; }

        [Column("work_on")]
        public DateTime work_on { get; set; }

        [Column("work_off")]
        public DateTime work_off { get; set; }

        [Column("eat_on")]
        public DateTime eat_on { get; set; }

        [Column("eat off")]
        public DateTime eat_off { get; set; }

        [NotMapped]
        public List<MenuInfo> menus { get; set; }
    }
}
