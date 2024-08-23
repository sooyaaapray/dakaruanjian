using ClockIn.Client.BLL;
using ClockIn.Client.Common;
using ClockIn.Client.DAL;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using ClockIn.Client.MainMoudels.Models;
using ClockIn.Client.MainMoudels.ViewModels;
using ClockIn.Client.MainMoudels.Views;
using ClockIn.Client.Startt.Base;
using ClockIn.Client.Startt.ViewModels;
using ClockIn.Client.Startt.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ClockIn.Client.Startt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
           return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            if (Container.Resolve<LoginView>().ShowDialog() == false)
            {
                Application.Current?.Shutdown();
            }
            else base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<NotificationContainer, NotificationContainer>();
            containerRegistry.Register<IEventAggregator, EventAggregator>();



            containerRegistry.Register<IWebDataBase, WebDataBase>();
            containerRegistry.Register<ILoginDAL, LoginDAL>();
            containerRegistry.Register<IClockInDAL, ClockInDAL>();
            containerRegistry.Register<IGetAllDAL, GetAllDAL>();
            containerRegistry.Register<IGetAllEventsDAL, GetAllEventsDAL>();
            containerRegistry.Register<IGetAllMessageDAL, GetAllMessageDAL>();


            containerRegistry.Register<IGetAllBll, GetAllBll>();
            containerRegistry.Register<IGetAllEventsBll, GetAllEventsBll>();
            containerRegistry.Register<IGetAllMessageBll, GetAllMessageBll>();
            containerRegistry.Register<IClockInBll, ClockInBll>();
            containerRegistry.Register<ILoginBll, LoginBll>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {

            moduleCatalog.AddModule<MainMoudels.MainModule>();
            moduleCatalog.AddModule<BaseModule.BaseInfoModule>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<LoginView, LogViewModel>();
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<LeftMeunView, LeftMenuViewModel>();
            ViewModelLocationProvider.Register<UserInfoView, UserInfoViewModel>();


        }
    }

}
