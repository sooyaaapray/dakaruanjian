using ClockIn.Client.BLL;
using ClockIn.Client.Entity;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        ClockInBll  _clockInBll;
        public HomeViewModel(ClockInBll clockInBll)
        {
            _clockInBll = clockInBll;
            //LoadPage();
        }
        public ICommand ClockIn
        {
            get => new DelegateCommand<object>(OnClockIn);
        }
        //打卡按钮
        private void OnClockIn(object obj)
        {
            CLoginUser cloginUser = CLoginUser._user_instance();
            if (cloginUser != null)
            {
                _clockInBll.ClockIn(ctype);
            }
        }
        public int _ctype;
        public int ctype
        {
            get
            {
                return _ctype;
            }
            set
            {
                if (_ctype != value)
                {
                    _ctype = value;
                    this.RaisePropertyChanged("ctype");
                }
            }
        }
        public string _Userlogname;
        public string Userlogname
        {
            get { return _Userlogname; }
            set { SetProperty<string>(ref _Userlogname, value); }
        }
        private void LoadPage()
        {
            //查询用户应打卡时间
            //先查最后一次打卡是吃饭打开还是上班打开
            //调整RadioButton的值
        }
    }
}
