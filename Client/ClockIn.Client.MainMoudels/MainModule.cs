﻿using ClockIn.Client.BaseModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.MainMoudels
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("leftMeumRegion", typeof(Views.LeftMeunView));
            regionManager.RegisterViewWithRegion("UserInfoRegion", typeof(Views.UserInfoView)); 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
