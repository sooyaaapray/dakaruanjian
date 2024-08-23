using ClockIn.Client.IBLL;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.BaseModule.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        IGetAllMessageBll _getAllMessageBll;
        public MessageViewModel(IGetAllMessageBll getAllMessageBll)
        {
            _getAllMessageBll= getAllMessageBll;
            LoadPage();
        }

        private void LoadPage()
        {
            //加载数据
        }
    }
}
