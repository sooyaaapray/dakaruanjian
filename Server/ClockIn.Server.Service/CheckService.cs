using ClockIn.Server.IService;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ClockIn.Server.Service
{
    public class CheckService : ServiceBase, ICheckService
    {
        DbContext _context;
        public CheckService(IEFContext.IEFContext eFContext) : base(eFContext)
        {
            _context = eFContext.CreateDBContext();
        }

        public int approve(LeaveCheckInfo leaveCheckInfo)
        {
            if (Update<LeaveCheckInfo>(leaveCheckInfo) > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<LeaveCheckInfo> getAllLeaveInfo()
        {
            return Query<LeaveCheckInfo>(x => true).ToList() ;
        }
    }
}
