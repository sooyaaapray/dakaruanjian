using ClockIn.Client.IDAL;

namespace ClockIn.Client.DAL
{
    public class GetAllDAL : IGetAllDAL
    {
        IWebDataBase _webDataBase;

        public GetAllDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<string> getAll()
        {
            return _webDataBase.PostDatas("api/user/getAllLeave", null);
        }
    }
}
