using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.DAL
{
    public class LeaveInsertDAL:ILeaveInsertDAL
    {
        IWebDataBase _webDataBase;
        public LeaveInsertDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<ResultData> leaveCheck(int user_id, string leaveEntity)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("user_id", new StringContent(user_id.ToString()));
            contents.Add("leaveEntity", new StringContent(leaveEntity));

            return _webDataBase.PostDatas("api/leave/CheckLeave", contents);
        }

        public Task<ResultData> leaveInsert(string leaveEntity)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("leaveEntity", new StringContent(leaveEntity));

            return _webDataBase.PostDatas("api/leave/AskForLeave", contents);
        }
    }
}
