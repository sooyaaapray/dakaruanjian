using ClockIn.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.DAL
{
    public class GetAllMessageDAL : IGetAllMessageDAL
    {
        IWebDataBase _webDataBase;

        public GetAllMessageDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<string> getAllMessage()
        {
            return _webDataBase.PostDatas("api/leave/AskForLeave", null);
        }
    }
}
