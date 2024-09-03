using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class LeaveInsertViewModel: BindableBase
    {
        public ICommand Cancel 
        {
            get => new DelegateCommand(cancel_func);
        }

        private void cancel_func()
        {
            _regionManager.RequestNavigate("MainContentRegion", "MessageView");
        }

        public ICommand Save
        {
            get => new DelegateCommand(save_func);
        }

        private void save_func()
        {
            CLoginUser curr_uer = CLoginUser._user_instance();
            LeaveEntity le =  new LeaveEntity();
            le.start_at = new DateOnly(startDate.Year,startDate.Month,startDate.Day);
            le.end_at= new DateOnly(endDate.Year, endDate.Month, endDate.Day);
            le.user_id = curr_uer.User_id;
            le.reason = reason;
            switch (LeaveTypeSelect) 
            {
                case "医疗": le._reason_type = reason_type.medical; break;
                case "旅行": le._reason_type = reason_type.travel; break;
                case "婚姻": le._reason_type = reason_type.marrage; break;
                case "走访": le._reason_type = reason_type.visit; break;
                default: le._reason_type = reason_type.other; break;
            }
            le._status = status.wait;
            le.approval_by = "";
            string les = JsonConvert.SerializeObject(le);
            _leaveInsertBll.leaveInsert(les);
        }

        IRegionManager _regionManager;
        ILeaveInsertBll _leaveInsertBll;
        public LeaveInsertViewModel(IRegionManager regionManager,ILeaveInsertBll leaveInsertBll)
        {
            _regionManager = regionManager;
            _leaveInsertBll = leaveInsertBll;
            LeaveType = new ObservableCollection<string>();
            LeaveType.Add("医疗");
            LeaveType.Add("旅行");
            LeaveType.Add("婚姻");
            LeaveType.Add("走访");
            LeaveType.Add("其他");
        }

        public string _LeaveTypeSelect;
        public string LeaveTypeSelect
        {
            get { return _LeaveTypeSelect; }
            set { SetProperty<string>(ref _LeaveTypeSelect, value); }
        }

        public ObservableCollection<string> _LeaveType;
        public ObservableCollection<string> LeaveType
        {
            get { return _LeaveType; }
            set { SetProperty<ObservableCollection<string>>(ref _LeaveType, value); }
        }

        public DateTime _startDate = System.DateTime.Today;
        public DateTime startDate
        {
            get { return _startDate; }
            set { SetProperty<DateTime>(ref _startDate, value); }
        }

        public DateTime _endtDate= System.DateTime.Today;
        public DateTime endDate
        {
            get { return _endtDate; }
            set { SetProperty<DateTime>(ref _endtDate, value); }
        }

        public string _reason;
        public string reason
        {
            get { return _reason; }
            set { SetProperty<string>(ref _reason, value); }
        }
    }
}
