using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class UserUpdateViewModel : BindableBase,INavigationAware
    {
        //private readonly IEventAggregator _eventAggregator;
        //private UserEntity _receivedUser;
        public ObservableCollection<string> _userRole;
        public ObservableCollection<string> userRole
        {
            get { return _userRole; }
            set { SetProperty<ObservableCollection<string>>(ref _userRole, value); }
        }

        bool flag = false;
        public ObservableCollection<string> _isAdministrtor;
        public ObservableCollection<string> isAdministrtor
        {
            get { return _isAdministrtor; }
            set { SetProperty<ObservableCollection<string>>(ref _isAdministrtor, value); }
        }

        public ObservableCollection<string> _isWork;
        public ObservableCollection<string> isWork
        {
            get { return _isWork; }
            set { SetProperty<ObservableCollection<string>>(ref _isWork, value); }
        }

        public UserEntity _userForUpdate;
        public UserEntity UserForUpdate
        {
            get { return _userForUpdate; }
            set { SetProperty<UserEntity>(ref _userForUpdate, value); }
        }
        public string _isWorkSelect;
        public string isWorkSelect
        {
            get { return _isWorkSelect; }
            set { SetProperty<string>(ref _isWorkSelect, value); }
        }

        public string _isAdministrtorSelect;
        public string isAdministrtorSelect
        {
            get { return _isAdministrtorSelect; }
            set { SetProperty<string>(ref _isAdministrtorSelect, value); }
        }

        public string _userRoleSelect;
        public string userRoleSelect
        {
            get { return _userRoleSelect; }
            set { SetProperty<string>(ref _userRoleSelect, value); }
        }

        IDialogService _dialogService;
        IRegionManager _regionManager;
        IUpdateUserInfoBll _updateUserInfoBll;
        public UserUpdateViewModel(IRegionManager regionManager, IDialogService dialogService,IUpdateUserInfoBll updateUserInfoBll)
        {
            _dialogService = dialogService;
            _regionManager = regionManager;
            _updateUserInfoBll= updateUserInfoBll;
            userRole = new ObservableCollection<string>();
            userRole.Add("老板");
            userRole.Add("管理员");
            userRole.Add("员工");
            isAdministrtor = new ObservableCollection<string>();
            isAdministrtor.Add("是");
            isAdministrtor.Add("否");
            isWork = new ObservableCollection<string>();
            isWork.Add("是");
            isWork.Add("否");
            //_eventAggregator = eventAggregator;
            //_eventAggregator.GetEvent<SendEvent>().Subscribe(OnReceived, ThreadOption.UIThread, true);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("select_user"))
            {
                flag = true;
                var select_user = navigationContext.Parameters["select_user"] as UserEntity;
                UserForUpdate = select_user;
                isWorkSelect = UserForUpdate.is_active ? "是" : "否";
                isAdministrtorSelect = _userForUpdate.is_admin ? "是" : "否";
                switch (_userForUpdate.user_role)
                {
                    case "Work": userRoleSelect = "员工"; break;
                    case "Boss": userRoleSelect = "老板"; break;
                    case "Administrator": userRoleSelect = "管理员"; break;
                    default: userRoleSelect = "员工"; break;
                }
            }
            else 
            {
                UserForUpdate = new UserEntity();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            UserForUpdate = null;
        }
        public ICommand Cancel {
            get => new DelegateCommand<Object>(cancel_func);
        }
        private void cancel_func(object obj)
        {
            //_dialogService.
            _regionManager.RequestNavigate("MainContentRegion", "MembersView");
        }
        public ICommand Save
        {
            get => new DelegateCommand<Object>(save_func);
        }

        private void save_func(object obj)
        {
            UserForUpdate.is_active = isWorkSelect == "是" ? true : false;
            UserForUpdate.is_admin = isAdministrtorSelect == "是" ? true : false;
            switch (userRoleSelect)
            {
                case "员工": UserForUpdate.user_role = "Work"; break;
                case "老板": UserForUpdate.user_role = "Boss"; break;
                case "管理员": UserForUpdate.user_role = "Administrator"; break;
                default: UserForUpdate.user_role = "Work"; break;
            }
            string up_user = JsonConvert.SerializeObject(UserForUpdate);
            if (flag)
            {
                _updateUserInfoBll.UpdateUserInfo(up_user);
            }
            else 
            {
                _updateUserInfoBll.insertUser(up_user);
            }
        }
    }
}
