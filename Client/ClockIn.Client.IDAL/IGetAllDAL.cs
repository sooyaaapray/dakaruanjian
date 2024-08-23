using ClockIn.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface IGetAllDAL
    {
        Task<ResultData> getAll();
        Task<ResultData> getUserById(int id);
        Task<ResultData> deleteUserById(int id);
    }
}
