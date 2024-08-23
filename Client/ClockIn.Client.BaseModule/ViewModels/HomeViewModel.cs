using ClockIn.Client.BLL;
using ClockIn.Client.Entity;
using Prism.Commands;
using Prism.Mvvm;
using System.Net.Sockets;
using System.Net;
using System.Windows.Input;
using System.Windows.Threading;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        ClockInBll  _clockInBll;
        private DateTime _now;
        public HomeViewModel(ClockInBll clockInBll)
        {
            _clockInBll = clockInBll;

            LoadPage();
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
        public string _curr_user_ip;
        public string curr_user_ip
        {
            get { return _curr_user_ip; }
            set { SetProperty<string>(ref _curr_user_ip, value); }
        }
        private string _current_timezone;
        public string current_timezone 
        {
            get
            {
                return _current_timezone;
            }
            set
            {
                SetProperty<string>(ref _current_timezone, value);
            }
        }
        private string _currentTime="00:00:00";
        public string currentTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                SetProperty<string>(ref _currentTime, value);
            }
        }
        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            currentTime = string.Format("{0}:{1}:{2}", d.Hour.ToString("00"), d.Minute.ToString("00"), d.Second.ToString("00"));
        }
        private void LoadPage()
        {

            current_timezone = TimeZoneInfo.Local.Id;
            curr_user_ip = GetLocalIPAddress();
            
            System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();


            //查询用户应打卡时间
            //先查最后一次打卡是吃饭打开还是上班打开
            //调整RadioButton的值
        }

        private string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            try
            {
                IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                foreach (IPAddress address in addresses)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIP = address.ToString();
                        break; // 找到第一个IPv4地址即停止遍历
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return localIP;
        }
    }
}
