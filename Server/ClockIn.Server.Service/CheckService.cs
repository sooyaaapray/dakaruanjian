using ClockIn.Server.IService;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using ClockIn.Server.Start.Common;

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

        public List<LeaveCheckInfo> getAllLeaveById(int user_id)
        {
            var sql = @$"select sys_leave.user_id,sys_leave.reason,sys_leave.status,sys_leave.created_at,sys_leave.updated_at,sys_leave.start_at,sys_leave.end_at,sys_leave.approval_by,sys_user_info.user_name from sys_leave left join sys_user_info on sys_user_info.user_id = sys_leave.user_id where sys_leave.user_id={user_id}";
            return  DynamicConverter.ConvertDynamicToGenericEntityList<LeaveCheckInfo>(ExecuteSqlQuery(sql).ToList());
        }

        public List<LeaveCheckInfo> getAllLeaveInfo()
        {
            return Query<LeaveCheckInfo>(x => true).ToList() ;
        }
    }
}
