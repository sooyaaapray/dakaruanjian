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
    public class UpdateUserService : ServiceBase, IUpdateUserService
    {
        DbContext _context;
        public UpdateUserService(IEFContext.IEFContext eFContext) : base(eFContext)
        {
            _context = eFContext.CreateDBContext();
        }

        //这两个方法后期建议采用token权限验证

        //如果非管理员返回空表
        public List<SysUserInfo> GetAllUser()
        {
            return Query<SysUserInfo>(x => true).ToList();
        }

        public int UpdateUser(SysUserInfo userInfo)
        {
            return Update<SysUserInfo>(userInfo);
        }
    }
}
