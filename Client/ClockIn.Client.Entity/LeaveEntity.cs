using System;

namespace ClockIn.Client.Entity
{
    public class LeaveEntity
    {
        public int leave_id { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public reason_type _reason_type { get; set; }
        public string reason { get; set; }
        public status _status { get; set; }
        public DateOnly start_at { get; set; }
        public DateOnly end_at { get; set; }
        public string approval_by { get; set; }
    }
    public enum reason_type
    {
        medical,
        travel,
        marrage,
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
