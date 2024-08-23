using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClockIn.Server.Models.ClockInState;

namespace ClockIn.Server.IService
{
    public interface IClockInService : IServiceBase
    {
        public int ClockIn(int user_id, state_Type _state_Type,string upTime);//打卡，返回打卡结果
    }
}
