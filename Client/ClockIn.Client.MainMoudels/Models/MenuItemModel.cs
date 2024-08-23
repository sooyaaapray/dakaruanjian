using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClockIn.Client.MainMoudels.Models
{
    public class MenuItemModel : BindableBase
    {
        private readonly IRegionManager _regionManager = null;
        public MenuItemModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public string _MenuIcon;
        public string MenuIcon
        {
            get { return _MenuIcon; }
            set { SetProperty(ref _MenuIcon, value); }
        }

        public string _MenuHeader;
        public string MenuHeader
        {
            get { return _MenuHeader; }
            set { SetProperty(ref _MenuHeader, value); }
        }

        public string _targetView;
        public string targetView
        {
            get { return _targetView; }
            set { SetProperty(ref _targetView, value); }
        }

        public ICommand OpenViewCommand
        {
            get => new DelegateCommand(() =>
            {
                if (string.IsNullOrEmpty(this.targetView) != null)
                {
                    //页面跳转
                    _regionManager.RequestNavigate("MainContentRegion", this.targetView);
                }
            }
                );
        }
    }
}
