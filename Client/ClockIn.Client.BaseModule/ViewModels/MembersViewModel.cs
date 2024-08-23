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
    public class MembersViewModel:BindableBase
    {
        IGetAllBll _getAllBll;
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
            _members = new List<CShowUser>();
            LoadPage();
        }
        public List<CShowUser> _members;
        public List<CShowUser> members 
        {
            get { return _members; }
            set
            {
                _members = value;
                SetProperty<List<CShowUser>>(ref _members,value);
            }
        }
        public ICommand ItemDeleteCommand
        {
            get => new DelegateCommand<object>(deleteItem);
        }
        private void deleteItem(object obj)
        {
            //弹窗，根据id删除用户信息
            _getAllBll.DeleteUserById(Convert.ToInt32(obj));
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
            //暂考虑使用全局单例对象
            UserForUpdate uf = UserForUpdate._user_instance();
            uf.User_id = ue.user_id;
            uf.User_name = ue.user_name;
            uf.Is_admin = ue.is_admin;
            uf.User_role = ue.user_role;
            uf.User_ip_address = ue.user_ip_address;
            uf.User_mac = ue.user_mac;
            uf.eat_off = ue.eat_off;
            uf.eat_on = ue.eat_on;
            uf.work_off = ue.work_off;
            uf.work_on = ue.work_on;
            _regionManager.RequestNavigate("MainContentRegion", "UserUpdateView");
        }
        private async void LoadPage()
        {
            //加载数据
            var converter = new BrushConverter();
            List<UserEntity> users= await _getAllBll.GetAll();

            foreach (var u in users) 
            {
                CShowUser uu = new CShowUser();
                uu.User_id = u.user_id;
                uu.User_name = u.user_name;
                uu.User_role = u.user_role;
                uu.User_ip_address = u.user_ip_address;
                uu.Tag = uu.User_role[0];
                
                switch (uu.User_role)
                {
                    case "Boss": uu.bColor = (Brush)converter.ConvertFromString("#6741D9"); break;
                    case "Management": uu.bColor = (Brush)converter.ConvertFromString("#FF8F00"); break;
                    case "Employee": uu.bColor = (Brush)converter.ConvertFromString("#1E88E5"); break;
                    default: uu.bColor = (Brush)converter.ConvertFromString("#1E88E5"); break;
                }
                members.Add(uu);
            }
            
        }
    }
}
