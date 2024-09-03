﻿using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IBLL
{
    public interface IGetAllMessageBll
    {
        Task<List<LeaveEntity>> getAllMessage(int user_id);
        Task<List<LeaveEntity>> getMessageById(int user_id);
    }
}
