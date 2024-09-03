using ClockIn.Client.Entity;
using System;
using System.Windows.Media;

namespace ClockIn.Client.BaseModule.CShows
{
    public class CShowMessage : LeaveEntity
    {
        public CShowMessage()
        {
            during_time = start_at.ToString() + "-" + end_at;
        }                 
        public string during_time { get; set; }
        public char tag { get; set; }
        public Brush bcolor { get; set; }
    }
}
