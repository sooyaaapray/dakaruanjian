using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.BLL
{
    public class LeaveInsertBll : ILeaveInsertBll
    {
        ILeaveInsertDAL _leaveInsertDAL;
        public LeaveInsertBll(ILeaveInsertDAL leaveInsertDAL)
        {
            _leaveInsertDAL = leaveInsertDAL;
        }

        public async Task<int> leaveCheck(int user_id, string leaveEntity)
        {
            var res = await _leaveInsertDAL.leaveCheck(user_id, leaveEntity);
            if ((int)res.StatusCode == 200)
            {
                return Convert.ToInt16(res.Result);
            }
            throw new Exception(res.StatusCode + res.Result);
        }

        public async Task<int> leaveInsert(string leaveEntity)
        {
            var res = await _leaveInsertDAL.leaveInsert(leaveEntity);
            if ((int)res.StatusCode == 200) 
            {
                return Convert.ToInt16(res.Result);    
            }
            throw new Exception(res.StatusCode + res.Result);
        }
    }
}
