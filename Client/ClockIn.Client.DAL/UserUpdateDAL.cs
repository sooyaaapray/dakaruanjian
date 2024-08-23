using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IDAL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.DAL
{
    public class UserUpdateDAL : IUserUpdateDAL
    {
        IWebDataBase _webDataBase;
        public UserUpdateDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<ResultData> GetAllUser(UserEntity CurUserEntity)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("is_admin", new StringContent(CurUserEntity.is_admin.ToString()));

            return _webDataBase.PostDatas("api/user/getalluser", contents);
        }

        public Task<ResultData> UpdateInfo(UserEntity TargetUserEntity, UserEntity CurUserEntity)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("is_admin", new StringContent(CurUserEntity.is_admin.ToString()));

            return _webDataBase.PostDatas("api/user/userupdate", contents);
        }
    }
}
