using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using System.Text.Json;

namespace ClockIn.Client.BLL
{
    public class LoginBll : ILoginBll
    {
        ILoginDAL _loginDAL;
        public LoginBll(ILoginDAL loginDAL)
        {
            _loginDAL = loginDAL;
        }
        public async Task<UserEntity> Login(string un, string pwd)
        {
            ResultData result = await _loginDAL.Login(un, pwd);

            if (result != null)
            {
                if ((int)result.StatusCode == 200)
                {
                    UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(result._resultData);
                    return userEntity;
                }
            }
            else 
            {
                throw new Exception(result.StatusCode.ToString() + result._resultData);
            }
            return null;
        }
    }

}
