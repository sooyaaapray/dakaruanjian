using ClockIn.Client.BLL;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using ClockIn.Client.Startt.Base;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace ClockIn.Client.Startt.ViewModels
{

    public class LogViewModel : BindableBase
    {
        ILoginBll _iloginBll;
        //Notif _notif;
        public LogViewModel(LoginBll loginBll)
        {
            _iloginBll = loginBll;
            //_notif = new Notif();
        }
        public string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty<string>(ref _Password, value); }
        }

        public string _Userlogname;
        public string Userlogname
        {
            get { return _Userlogname; }
            set { SetProperty<string>(ref _Userlogname, value); }
        }

        public ICommand logButtonCommand
        {
            get => new DelegateCommand<object>(OnLogin);
        }

        private void OnLogin(object obj)
        {
            try
            {
                if (string.IsNullOrEmpty(this._Userlogname))
                {
                    throw new Exception("登录失败，请输入登录名");
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    throw new Exception("登录失败，请输入密码");
                }
                UserEntity ue = _iloginBll.Login(this.Userlogname, this.Password).GetAwaiter().GetResult();

                if (ue != null)
                {
                    //登录成功
                    //设置全局单例登录用户对象
                    CLoginUser cLoginUser = CLoginUser._user_instance();
                    cLoginUser.User_id = ue.user_id;
                    cLoginUser.User_name = ue.user_name;
                    cLoginUser.User_ip_address = ue.user_ip_address;
                    cLoginUser.User_mac = ue.user_mac;
                    cLoginUser.Is_admin = ue.is_admin;
                    cLoginUser.User_role = ue.user_role;
                    cLoginUser.work_on = ue.work_on;
                    cLoginUser.work_off = ue.work_off;
                    cLoginUser.eat_on = ue.eat_on;
                    cLoginUser.eat_off = ue.eat_off;
                    cLoginUser.menus = ue.menus;
                    //打开主窗口
                    (obj as Window).DialogResult = true;
                }
                else
                {
                    //登录失败
                    throw new Exception("登录失败，请检查登录名或密码是否正确");
                }
            }
            catch (Exception ex)
            {
                //_notif.notifier.ShowInformation(ex.Message);
            }
}
    }
}
