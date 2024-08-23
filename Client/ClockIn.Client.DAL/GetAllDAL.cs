using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IDAL;
using Microsoft.VisualBasic;

namespace ClockIn.Client.DAL
{
    public class GetAllDAL : IGetAllDAL
    {
        IWebDataBase _webDataBase;

        public GetAllDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<ResultData> deleteUserById(int id)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("id", new StringContent(id.ToString()));
            return _webDataBase.PostDatas("api/user/deleteuserById", contents);
        }

        public Task<ResultData> getAll()
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("isAdmin", new StringContent(CLoginUser._user_instance().Is_admin.ToString()));
            return _webDataBase.PostDatas("api/user/getall", contents);
        }

        public Task<ResultData> getUserById(int id)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("id", new StringContent(id.ToString()));
            return _webDataBase.PostDatas("api/user/getuserById", contents);
        }
    }
}
