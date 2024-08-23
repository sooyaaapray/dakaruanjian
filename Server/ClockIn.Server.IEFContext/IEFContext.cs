using ClockIn.Server.EF;

namespace ClockIn.Server.IEFContext
{
    public interface IEFContext
    {
       EFContext CreateDBContext();
    }
}
