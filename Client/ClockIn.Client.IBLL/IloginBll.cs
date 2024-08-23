using ClockIn.Client.Entity;

namespace ClockIn.Client.IBLL
{
    public interface ILoginBll
    {
        Task<UserEntity> Login(string un, string pwd);
    }
}
