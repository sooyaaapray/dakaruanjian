using ClockIn.Server.IService;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            return Query<SysUserInfo>(x => x.is_active==true).ToList();
        }

        public int UpdateUser(SysUserInfo user)
        {
            var sql = @"update sys_user_info set "+
                        $"user_login_name='{user.user_login_name}'," +
                        $"user_name='{user.user_name}',"+
                        $"user_role ='{user.user_role}',"+
                        $"user_ip_address ='{user.user_ip_address}',"+
                        $"user_mac='{user.user_mac}',"+
                        $"user_pwd='{user.user_pwd}',"+
                        $"eat_on='{user.eat_on}',"+
                        $"eat_off='{user.eat_off}',"+
                        $"work_on='{user.work_on}',"+
                        $"work_off='{user.work_off}',"+
                        $"is_admin={user.is_admin},"+
                        $"is_active={user.is_active} "+
                        $"where user_id={user.user_id}";
            return ExecuteNonQuery(sql);
        }
        public int deleteUserById(int id) {
            var sql = @$"update sys_user_info set is_active=false where user_id={id}";
            return ExecuteNonQuery(sql);
        }
    }
}
