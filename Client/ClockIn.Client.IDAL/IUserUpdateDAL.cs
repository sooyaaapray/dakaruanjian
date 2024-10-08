﻿using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.IDAL
{
    public interface IUserUpdateDAL
    {
        Task<ResultData> UpdateInfo(string select_user);
        Task<ResultData> insertUser(string user);
        Task<ResultData> GetAllUser(UserEntity CurUserEntity);
    }
}
