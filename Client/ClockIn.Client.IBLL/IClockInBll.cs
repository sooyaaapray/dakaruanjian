﻿using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IBLL
{
    public interface IClockInBll
    {
        Task<int> ClockIn(int ctype);
    }
}
