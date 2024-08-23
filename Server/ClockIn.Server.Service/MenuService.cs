using ClockIn.Server.IService;
using ClockIn.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Server.Service
{
    public class MenuService : ServiceBase, IMenuService
    {
        DbContext _context;
        public MenuService(IEFContext.IEFContext eFContext) : base(eFContext)
        {
            _context = eFContext.CreateDBContext();
        }

        public List<MenuInfo> GetMenusByRole(bool isAdmin)
        {
            if (isAdmin)
            {
                return (from menu in Context.Set<MenuInfo>()
                        select menu).ToList();
            }
            else {
                return (from menu in Context.Set<MenuInfo>()
                        where menu.MenuType == false
                        select menu).ToList();
            }
        }
    }
}
