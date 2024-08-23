using ClockIn.Server.IService;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClockIn.Server.Models.ClockInState;

namespace ClockIn.Server.Service
{
    public class ClockInService : ServiceBase, IClockInService
    {
        DbContext _context;
        public ClockInService(IEFContext.IEFContext eFContext) : base(eFContext)
        {
            _context = eFContext.CreateDBContext();
        }

        public int ClockIn(int user_id, state_Type _state_Type,string upTime)
        {
            DateTime clientTime = Convert.ToDateTime(upTime);
            DateTime now = DateTime.Now;
            if (clientTime.AddSeconds(20) >= now || clientTime.AddSeconds(-20) <= now)
            {
                ClockInInfo ci = new ClockInInfo();
                ci.user_id = user_id;
                ci.record_code = _state_Type;
                ci.record_date = now;
                if (Insert<ClockInInfo>(ci) != null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else {
                //客户端时间错误,不能打卡
                return 2;
            }
            
        }
    }
}
