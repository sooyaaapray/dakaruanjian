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

        public Task<ResultData> getAllEvents()
        {
            return _webDataBase.PostDatas("api/leave/CheckLeave", null);
        }
    }
}
