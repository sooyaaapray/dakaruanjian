﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface IGetAllEventsDAL
    {
        Task<string> getAllEvents();
    }
}
