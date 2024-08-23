namespace ClockIn.Client.IDAL
{
    public interface ILoginDAL
    {
        Task<string> Login(string username, string password);
    }
}
