using ClockIn.Client.Entity;
using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIn.Client.BLL
{
    public class ClockInBll : IClockInBll
    {
        IClockInDAL _clockInDAL;
        public ClockInBll(IClockInDAL clockInDAL)
        {
            _clockInDAL = clockInDAL; ;
        }
        public async Task<UserEntity> ClockIn(int ctype)
        {
            CLoginUser cLoginUser = CLoginUser._user_instance();
            string result = await _clockInDAL.ClockIn(ctype, cLoginUser.User_id);

            //ResultEntity<List<string>>
            UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(result);

            return userEntity;
        }
    }
}
