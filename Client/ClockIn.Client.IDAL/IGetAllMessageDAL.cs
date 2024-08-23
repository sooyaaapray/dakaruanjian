using ClockIn.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface IGetAllMessageDAL
    {
        Task<ResultData> getAllMessage();
    }
}
