using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace ClockIn.Client.BLL
{
    public class GetAllMessageBll : IGetAllMessageBll
    {
        IGetAllMessageDAL _getAllMessageDAL;
        public GetAllMessageBll(IGetAllMessageDAL getAllMessageDAL)
        {
            _getAllMessageDAL = getAllMessageDAL;
        }

        public async Task<List<LeaveEntity>> getAllMessage(int user_id)
        {
            ResultData res = await _getAllMessageDAL.getAllMessage(user_id);
            if (res != null)
            {
                if ((int)res.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<LeaveEntity>>(res.Result);
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString() + res._resultData);
                }
            }
            throw new Exception(HttpStatusCode.GatewayTimeout+"数据访问失败");
        }

        public async Task<List<LeaveEntity>> getMessageById(int user_id)
        {
            ResultData res = await _getAllMessageDAL.getMessageById(user_id);
            if (res != null)
            {
                if ((int)res.StatusCode == 200)
                {
                    return JsonConvert.DeserializeObject<List<LeaveEntity>>(res.Result);
                }
                else
                {
                    throw new Exception(res.StatusCode.ToString() + res._resultData);
                }
            }
            throw new Exception(HttpStatusCode.GatewayTimeout + "数据访问失败");
        }
    }
}
