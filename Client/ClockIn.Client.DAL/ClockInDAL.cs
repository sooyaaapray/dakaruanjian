using ClockIn.Client.Common;
using ClockIn.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.DAL
{
    public class ClockInDAL : IClockInDAL
    {
        IWebDataBase _webDataBase;

        public ClockInDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<ResultData> ClockIn(int ctype, int user_id)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("user_id", new StringContent(user_id.ToString()));
            contents.Add("code", new StringContent(ctype.ToString()));
            
            contents.Add("upTime", new StringContent(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));

            return _webDataBase.PostDatas("api/leave/clockin", contents);
        }
    }
}
