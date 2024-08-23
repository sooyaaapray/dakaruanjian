using ClockIn.Client.Common;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.BLL
{
    public class GetAllEventsBll : IGetAllEventsBll
    {
        IGetAllEventsDAL _getAllEventsDAL;
        public GetAllEventsBll(IGetAllEventsDAL getAllEventsDAL)
        {
            _getAllEventsDAL = _getAllEventsDAL;
        }
        public Task<ResultData> getAllEvents()
        {
           return _getAllEventsDAL.getAllEvents();
        }
    }
}
