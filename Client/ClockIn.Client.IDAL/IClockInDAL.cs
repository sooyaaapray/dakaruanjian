using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface IClockInDAL
    {
        Task<string> ClockIn(int ctype,int user_id);
    }
}
