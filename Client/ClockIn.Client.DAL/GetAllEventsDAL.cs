using ClockIn.Client.Common;
using ClockIn.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.DAL
{
    public class GetAllEventsDAL : IGetAllEventsDAL
    {
        IWebDataBase _webDataBase;

        public GetAllEventsDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<ResultData> getAllEvents(int user_id)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("user_id", new StringContent(user_id.ToString()));

            return _webDataBase.PostDatas("api/leave/getallevent", contents);
        }
    }
}
