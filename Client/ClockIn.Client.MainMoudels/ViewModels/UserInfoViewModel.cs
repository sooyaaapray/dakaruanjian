using ClockIn.Client.Entity;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.MainMoudels.ViewModels
{
    public class UserInfoViewModel : BindableBase
    {
        public UserInfoViewModel(IContainerProvider containerProvider)
        {
            CLoginUser cLoginUser = CLoginUser._user_instance();
            if (cLoginUser != null) {
                userName = cLoginUser.User_name;
                userRole = cLoginUser.User_role;
            }
        }
        public string _userName;
        public string userName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public string _userRole;
        public string userRole
        {
            get { return _userRole; }
            set { SetProperty(ref _userRole, value); }
        }
    }
}
