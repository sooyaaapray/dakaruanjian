using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IBLL
{
    public interface IUpdateUserInfoBll
    {
        public Task<int> UpdateUserInfo(string user_select);
        public Task<UserEntity> insertUser(string user);
    }
}
