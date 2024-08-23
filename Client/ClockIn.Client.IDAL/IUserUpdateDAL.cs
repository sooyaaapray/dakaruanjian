using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface IUserUpdateDAL
    {
        Task<string> UpdateInfo(UserEntity TargetUserEntity, UserEntity CurUserEntity);
        Task<string> GetAllUser(UserEntity CurUserEntity);
    }
}
