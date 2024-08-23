using ClockIn.Server.IConfiguration;
using ClockIn.Server.IEFContext;

namespace ClockIn.Server.EFContext
{
    public class EFContext : IEFContext.IEFContext
    {
        IConfiguration.IConfiguration _configuration;
        public EFContext(IConfiguration.IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public EF.EFContext CreateDBContext()
        {
            return new EF.EFContext(_configuration.Read("ConStr"));
        }
    }
}
