using ClockIn.Client.BaseModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.BaseModule
{
    public class BaseInfoModule : IModule
    {

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.HomeView,ViewModels.HomeViewModel>("HomeView");
            containerRegistry.RegisterForNavigation<Views.MembersView,ViewModels.MembersViewModel>("MembersView");
            containerRegistry.RegisterForNavigation<Views.EventsView,ViewModels.EventsViewModel>("EventsView");
            containerRegistry.RegisterForNavigation<Views.MessageView, ViewModels.MessageViewModel>("MessageView");
            containerRegistry.RegisterForNavigation<Views.UserUpdateView, ViewModels.UserUpdateViewModel>("UserUpdateView");
        }
    }
}
