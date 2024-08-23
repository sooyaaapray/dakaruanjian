﻿using ClockIn.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Server.IService
{
    public interface ICheckService:IServiceBase
    {
        public List<LeaveCheckInfo> getAllLeaveInfo();
        public int approve(LeaveCheckInfo leaveCheckInfo);
    }
}
