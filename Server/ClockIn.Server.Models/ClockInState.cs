using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Server.Models
{
    public class ClockInState
    {
        public enum state_Type
        {
            /// <summary>
            /// 当日考勤总值
            /// 0为当日缺勤
            /// 
            /// 
            /// </summary>
            [Description("上班打卡")]
            work_on = 1,

            [Description("上班迟到打卡")]
            work_on_late = 2,

            [Description("吃饭早退打卡")]
            rest_on_early = 4,

            [Description("吃饭开始打卡")]
            rest_on = 8,

            [Description("吃完结束打卡")]
            rest_off = 16,

            [Description("吃完结束迟到打卡")]
            rest_off_late = 32,

            [Description("下班早退打卡")]
            work_off_early = 64,

            [Description("下班打卡")]
            work_off = 128
        }
    }
}
