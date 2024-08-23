using ClockIn.Client.Common;
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
    public class GetAllBll: IGetAllBll
    {
        IGetAllDAL _getAllDAL;
        public GetAllBll(IGetAllDAL getAllDAL)
        {
            _getAllDAL = getAllDAL;
        }

        public async Task<List<UserEntity>> GetAll() 
        {
            ResultData result = await _getAllDAL.getAll();
            if ((int)result.StatusCode == 200) {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserEntity>>(result.Result);
            }
            throw new Exception(result.StatusCode + result.Result);
        }

        public async Task<UserEntity> GetUserById(int id)
        {
            ResultData result = await _getAllDAL.getUserById(id);
            if ((int)result.StatusCode == 200) {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(result.Result);
            }
            throw new Exception(result.StatusCode + result.Result);
        }

        public async Task<int> DeleteUserById(int id)
        {
            ResultData result = await _getAllDAL.deleteUserById(id);
            if ((int)result.StatusCode == 200)
            {
                return Convert.ToInt32(result.Result);
            }
            throw new Exception(result.StatusCode + result.Result);
        }
    }
}
