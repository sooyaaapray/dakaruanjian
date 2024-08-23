using ClockIn.Client.Common;

namespace ClockIn.Client.IDAL
{
    public interface ILoginDAL
    {
        Task<ResultData> Login(string username, string password);
    }
}
