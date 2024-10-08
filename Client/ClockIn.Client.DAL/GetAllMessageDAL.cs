﻿using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IDAL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.DAL
{
    public class GetAllMessageDAL : IGetAllMessageDAL
    {
        IWebDataBase _webDataBase;

        public GetAllMessageDAL(IWebDataBase webDataBase)
        {
            _webDataBase = webDataBase;
        }

        public Task<ResultData> getMessageById(int user_id)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("user_id", new StringContent(user_id.ToString()));

            return _webDataBase.PostDatas("api/leave/getLeavebyid", contents);
        }

        public Task<ResultData> getAllMessage(int user_id)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("user_id", new StringContent(user_id.ToString()));

            return _webDataBase.PostDatas("api/leave/getallleave", contents);
        }
    }
}
