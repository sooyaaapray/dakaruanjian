using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface ILeaveInsertDAL
    {
        public Task<ResultData> leaveInsert(string leaveEntity);
        public Task<ResultData> leaveCheck(int user_id,string leaveEntity);
    }
}
