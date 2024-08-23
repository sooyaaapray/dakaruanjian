using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using Prism.Events;
using Prism.Mvvm;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class UserUpdateViewModel:BindableBase
    {
        //private readonly IEventAggregator _eventAggregator;
        //private UserEntity _receivedUser;
        public UserForUpdate _userForUpdate;
        public UserForUpdate UserForUpdate
        {
            get { return _userForUpdate; }
            set { SetProperty<UserForUpdate>(ref _userForUpdate, value); }
        }
        public UserUpdateViewModel()
        {
            _userForUpdate = UserForUpdate._user_instance();
            //_eventAggregator = eventAggregator;
            //_eventAggregator.GetEvent<SendEvent>().Subscribe(OnReceived, ThreadOption.UIThread, true);
        }
        /*public UserEntity ReceivedUser
        {
            get => _receivedUser;
            set => SetProperty(ref _receivedUser, value);
        }

        private void OnReceived(UserEntity receivedUser)
        {
            ReceivedUser = receivedUser;
        }*/
    }
}
