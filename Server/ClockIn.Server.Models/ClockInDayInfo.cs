using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ClockIn.Server.Models.ClockInState;

namespace ClockIn.Server.Models
{
    [Table("sys_clockin_day")]
    public class ClockInDayInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("record_day_id")]
        public int record_id { get; set; }

        [Column("user_id")]
        public int user_id { get; set; }

        [Column("record_date_day")]
        public DateTime record_date_day { get; set; }

        [Column("record_code_totall")]
        public state_Type record_code_totall { get; set; }
    }
}
