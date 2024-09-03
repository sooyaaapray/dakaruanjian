using ClockIn.Client.BaseModule.CShows;
using ClockIn.Client.BLL;
using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class MembersViewModel:BindableBase, INavigationAware
    {
        IGetAllBll _getAllBll;
        List<UserEntity> users;
        public ICommand addmember 
        {
            get => new DelegateCommand<object>(AddMember);
        }
        private void AddMember(object obj) 
        {
            //UserForUpdate.clear();
            _regionManager.RequestNavigate("MainContentRegion", "UserUpdateView");
        }
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        public MembersViewModel(IGetAllBll getAllBll,IRegionManager regionManager)
        {
            //_eventAggregator=eventAggregator;
            _regionManager = regionManager;
            _getAllBll = getAllBll;
            _members = new ObservableCollection<CShowUser>();
            LoadPage();
        }
        public ObservableCollection<CShowUser> _members;
        public ObservableCollection<CShowUser> members 
        {
            get { return _members; }
            set
            {
                _members = value;
                SetProperty<ObservableCollection<CShowUser>>(ref _members,value);
            }
        }
        public ICommand ItemDeleteCommand
        {
            get => new DelegateCommand<object>(deleteItem);
        }
        private async void deleteItem(object obj)
        {
            //弹窗，根据id删除用户信息
            int id = Convert.ToInt32(obj);
            int ress = await _getAllBll.DeleteUserById(id);
            if (ress == 1) 
            {
                removeById(members,id);
            }
        }
        private void removeById<T>(Collection<T> ts,int id) where T:UserEntity 
        {
            int l = ts[0].user_id, r = ts[ts.Count()-1].user_id;
            while (l<=r) 
            {
                int m = l + (r - l) / 2;
                if (ts[m].user_id == id) 
                {
                    ts.Remove(ts[m]);
                    return;
                }
                if (ts[m].user_id > id)
                    r = m - 1;
                else
                    l = m + 1;
            }
        }
        public ICommand ItemUpdateCommand
        {
            get => new DelegateCommand<object>(updateItem);
        }
        private async void updateItem(object obj) 
        {
            //根据id查询该用户的所有信息，并将信息push到EventAggregator到跳转到update页
            UserEntity ue = await _getAllBll.GetUserById(Convert.ToInt32(obj));
            //_eventAggregator.GetEvent<SendEvent>().Publish(ue);
            var nparams = new NavigationParameters();
            nparams.Add("select_user",ue);
            _regionManager.RequestNavigate("MainContentRegion", "UserUpdateView", nparams);
        }
        private async void LoadPage()
        {
            //加载数据
            var converter = new BrushConverter();
            users= await _getAllBll.GetAll();

            foreach (var u in users) 
            {
                CShowUser uu = new CShowUser();
                uu.user_id = u.user_id;
                uu.user_name = u.user_name;
                uu.user_role = u.user_role;
                uu.user_ip_address = u.user_ip_address;
                uu.tag = uu.user_role[0];
                
                switch (uu.user_role)
                {
                    case "Boss": uu.bcolor = (Brush)converter.ConvertFromString("#6741D9"); break;
                    case "Management": uu.bcolor = (Brush)converter.ConvertFromString("#FF8F00"); break;
                    case "Employee": uu.bcolor = (Brush)converter.ConvertFromString("#1E88E5"); break;
                    default: uu.bcolor = (Brush)converter.ConvertFromString("#1E88E5"); break;
                }
                members.Add(uu);
            }
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
