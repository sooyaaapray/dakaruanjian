using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.BLL
{
    public class UpdateUserInfoBll:IUpdateUserInfoBll
    {
        IUserUpdateDAL _updateUserInfoDAL;
        public UpdateUserInfoBll(IUserUpdateDAL updateUserDAL)
        {
            _updateUserInfoDAL= updateUserDAL;
        }

        public async Task<UserEntity> insertUser(string user)
        {
            ResultData res = await _updateUserInfoDAL.insertUser(user);
            if (res != null)
            {
                if ((int)res.StatusCode == 200)
                {
                    return  JsonConvert.DeserializeObject<UserEntity>(res.Result);
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString() + res._resultData);
                }
            }
            return null;
        }

        public async Task<int> UpdateUserInfo(string user_select)
        {
            ResultData res = await _updateUserInfoDAL.UpdateInfo(user_select);
            if (res != null) {
                if ((int)res.StatusCode == 200)
                {
                    return Convert.ToInt32(res.Result);
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString() + res._resultData);
                }
            }
            return 0;
        }
    }
}
