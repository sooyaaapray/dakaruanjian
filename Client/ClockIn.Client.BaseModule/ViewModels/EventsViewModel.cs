using ClockIn.Client.IBLL;
using Prism.Mvvm;


namespace ClockIn.Client.BaseModule.ViewModels
{
    public class EventsViewModel : BindableBase
    {
        IGetAllEventsBll _getAllEventsBll;
        public EventsViewModel(IGetAllEventsBll getAllEventsBll)
        {

        }

        private void LoadPage()
        {
            _getAllEventsBll.getAllEvents();
            //加载数据
        }
    }
}
