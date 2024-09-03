using ClockIn.Client.BaseModule.CShows;
using ClockIn.Client.BLL;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using Prism.Mvvm;
using System.Windows.Media;


namespace ClockIn.Client.BaseModule.ViewModels
{
    public class EventsViewModel : BindableBase
    {
        IGetAllEventsBll _getAllEventsBll;
        public EventsViewModel(IGetAllEventsBll getAllEventsBll)
        {

        }

        private async void LoadPage()
        {
            //加载数据
            CLoginUser curr_user = CLoginUser._user_instance();
            if (curr_user != null)
            {
                var converter = new BrushConverter();
                
            }
            throw new Exception("");

        }
    }
}
