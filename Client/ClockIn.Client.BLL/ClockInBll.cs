using ClockIn.Client.Common;
using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using System;

namespace ClockIn.Client.BLL
{
    public class ClockInBll : IClockInBll
    {
        IClockInDAL _clockInDAL;
        public ClockInBll(IClockInDAL clockInDAL)
        {
            _clockInDAL = clockInDAL; ;
        }
        public async Task<int> ClockIn(int ctype)
        {
            CLoginUser cLoginUser = CLoginUser._user_instance();
            if (cLoginUser != null)
            {
                ResultData result = await _clockInDAL.ClockIn(ctype, cLoginUser.User_id);
                if (result != null)
                {
                    if ((int)result.StatusCode == 200)
                    {
                        //弹窗打卡成功
                        return 1;
                    }
                    else {
                        throw new Exception(result.Result);
                    }
                }
                throw new Exception("打卡失败");
            }
            else {
                //请先登录再打卡，跳转回登录页
                throw new Exception("请先登录之后再打卡");
            }
        }
    }
}
