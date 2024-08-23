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

        public Task<string> ClockIn(int ctype, int user_id)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("ctype", new StringContent(ctype.ToString()));
            contents.Add("user_id", new StringContent(user_id.ToString()));

            return _webDataBase.PostDatas("api/leave/clockin", contents);
        }
    }
}
