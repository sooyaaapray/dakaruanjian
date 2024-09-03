using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IBLL
{
    public interface ILeaveInsertBll
    {
        Task<int> leaveInsert(string leaveEntity);
        Task<int> leaveCheck(int user_id, string leaveEntity);
    }
}
