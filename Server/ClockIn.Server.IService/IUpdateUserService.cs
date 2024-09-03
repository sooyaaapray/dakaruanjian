using ClockIn.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Server.IService
{
    public interface IUpdateUserService : IServiceBase
    {
        List<Models.SysUserInfo> GetAllUser();

        int UpdateUser(SysUserInfo user);

        int deleteUserById(int id);
    }
}
