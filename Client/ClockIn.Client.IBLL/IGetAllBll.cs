using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IBLL
{
    public interface IGetAllBll
    {
        Task<List<UserEntity>> GetAll();
        Task<UserEntity> GetUserById(int id);
        Task<int> DeleteUserById(int id);
    }
}
