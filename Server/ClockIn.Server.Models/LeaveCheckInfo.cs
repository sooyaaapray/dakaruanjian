using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClockIn.Server.Models
{
    [Table("sys_leave")]
    public class LeaveCheckInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("leave_id")]
        public int leave_id { get; set; }

        [Column("user_id")]
        public int user_id { get; set; }

        [Column("reason_type", TypeName = "tinyint")]
        reason_type _reason_type { get; set; }

        [Column("reason")]
        public string reason { get; set; }

        [Column("status", TypeName = "tinyint")]
        public status _status { get; set; }

        [Column("created_at")]
        public DateTime created_at { get; set; }

        [Column("start_at")]
        public DateTime start_at { get; set; }

        [Column("end_at")]
        public DateTime end_at { get; set; }

        [Column("updated_at")]
        public DateTime updated_at { get; set; }

        [Column("approval_by")]
        public string approval_by { get; set; }
    }

    public enum reason_type
    {
        medical,
        travel,
        visit,
        other
    }

    public enum status
    {
        approvaled,
        refuse,
        wait
    }
}
