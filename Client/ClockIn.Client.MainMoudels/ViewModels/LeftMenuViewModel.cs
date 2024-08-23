using ClockIn.Client.Entity;
using ClockIn.Client.MainMoudels.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.MainMoudels.ViewModels
{
    public class LeftMenuViewModel
    {
        public List<MenuItemModel> menus { get; set; } = new List<MenuItemModel>();
        private List<MenuEntity> menuEntities = null;

        IRegionManager _regionManager;
        public LeftMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            menuEntities = CLoginUser._user_instance().menus;
            this.FillMenu(menus);
        }

        private void FillMenu(List<MenuItemModel> menus) {
            var sub = menuEntities.Where(m => m.State == 1);
            foreach (var it in sub) {
                MenuItemModel mm = new MenuItemModel(_regionManager);
                mm.MenuHeader = it.MenuHeader;
                mm.MenuIcon = it.MenuIcon;
                mm.targetView = it.targetView;
                menus.Add(mm);
            }
        }
    }
}
