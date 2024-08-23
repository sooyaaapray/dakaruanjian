using ClockIn.Server.IEFContext;
using ClockIn.Server.IService;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClockIn.Server.Service
{
    public class LoginService : ServiceBase,ILoginService
    {
        DbContext _context;
        public LoginService(IEFContext.IEFContext eFContext):base(eFContext)
        {
            _context = eFContext.CreateDBContext();
        }
    }
}
