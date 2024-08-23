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
            // 将DAL返回的Json字符串    反序列化成   直接对象
            string result = await _loginDAL.Login(un, pwd);

            //ResultEntity<List<string>>
            UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(result);

            return userEntity;


            /*ResultEntity<UserEntity> re = JsonSerializer.Deserialize<ResultEntity<UserEntity>>(result);
            if (re != null)
            {
                if (re.state == 200)
                {
                    return re.data;
                }
                else
                {
                    // 记录日志   异常码   500     501   其他错
                    throw new Exception(re.exceptionMessage);
                }
            }*/
            //return null;
        }
    }

}
