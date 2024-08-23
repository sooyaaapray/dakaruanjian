using ClockIn.Server.IService;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Server.Service
{
    public class LeaveService : ServiceBase, ILeaveService
    {
        DbContext _context;
        public LeaveService(IEFContext.IEFContext eFContext) : base(eFContext)
        {
            _context = eFContext.CreateDBContext();
        }

        public int Leave(LeaveCheckInfo leaveCheckInfo) {
            if (Insert<LeaveCheckInfo>(leaveCheckInfo) != null)
            {
                return 0;
            }
            else return 1;
        }
    }
}
