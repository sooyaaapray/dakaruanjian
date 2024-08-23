using ClockIn.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IBLL
{
    public interface IGetAllEventsBll
    {
        Task<ResultData> getAllEvents();
    }
}
