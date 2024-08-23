using ClockIn.Server.Models;

namespace ClockIn.Server.IService
{
    public  interface IMenuService:IServiceBase
    {
        List<MenuInfo> GetMenusByRole(bool isAdmin);
    }
}
