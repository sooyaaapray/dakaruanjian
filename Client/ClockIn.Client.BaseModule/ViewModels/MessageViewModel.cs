using ClockIn.Client.BaseModule.CShows;
using ClockIn.Client.BLL;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class MessageViewModel : BindableBase, INavigationAware
    {
        private IGetAllMessageBll _getAllMessageBll;
        private IRegionManager _regionManager;
        private List<LeaveEntity> leaves;
        public MessageViewModel(IRegionManager regionManager, IGetAllMessageBll getAllMessageBll)
        {
            _regionManager = regionManager;
            _getAllMessageBll = getAllMessageBll;
            LoadPage();
        }

        public ObservableCollection<CShowMessage> _leavess;
        public ObservableCollection<CShowMessage> leavess
        {
            get { return _leavess; }
            set
            {
                _leavess = value;
                SetProperty<ObservableCollection<CShowMessage>>(ref _leavess, value);
            }
        }

        private async void LoadPage()
        {
            //加载数据
            CLoginUser curr_user = CLoginUser._user_instance();
            try
            {
                if (curr_user != null)
                {
                    var converter = new BrushConverter();
                    leaves = await _getAllMessageBll.getMessageById(curr_user.User_id);

                    foreach (var u in leaves)
                    {
                        CShowMessage csm = new CShowMessage();
                    }
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {
                //toast
            }
        }

        public ICommand leaveAdd
        {
            get => new DelegateCommand(leaveInsertFunc);
        }

        private void leaveInsertFunc()
        {
            _regionManager.RequestNavigate("MainContentRegion", "LeaveInsertView");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
