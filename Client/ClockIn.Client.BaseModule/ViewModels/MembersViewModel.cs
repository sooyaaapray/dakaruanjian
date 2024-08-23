using ClockIn.Client.BLL;
using ClockIn.Client.IBLL;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class MembersViewModel:BindableBase
    {
        IGetAllBll _getAllBll;
        public ICommand addmember 
        {
            get => new DelegateCommand<object>(AddMember);
        }
        private void AddMember(object obj) 
        {
            _regionManager.RequestNavigate("MainContentRegion", "UserUpdateView");
        }
        private readonly IRegionManager _regionManager;
        public MembersViewModel(IGetAllBll getAllBll,IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _getAllBll = getAllBll;
            LoadPage();
        }

        private void LoadPage()
        {
            //加载数据
        }
    }
}
