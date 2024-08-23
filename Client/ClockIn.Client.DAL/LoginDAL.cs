using ClockIn.Client.IDAL;

namespace ClockIn.Client.DAL
{
    public class LoginDAL : ILoginDAL
    {
        IWebDataBase _webDataBase;

        public LoginDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<string> Login(string username, string password)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("userlogname", new StringContent(username));
            contents.Add("password", new StringContent(password));

            return _webDataBase.PostDatas("api/user/login", contents);  
        }

    }
}
