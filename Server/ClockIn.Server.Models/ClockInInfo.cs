using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClockIn.Server.Models.ClockInState;

namespace ClockIn.Server.Models
{
    [Table("sys_clockin")]
    public class ClockInInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("record_id")]
        public int record_id { get; set; }

        [Column("user_id")]
        public int user_id { get; set; }

        [Column("record_date")]
        public DateTime record_date { get; set; }

        [Column("record_code")]
        public state_Type record_code { get; set; }
    }
}