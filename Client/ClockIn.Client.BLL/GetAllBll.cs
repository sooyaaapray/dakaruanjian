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
        public async Task<string> GetAll() 
        {
            string restult = await _getAllDAL.getAll();
         
            //UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(result);
            return restult;
        }
    }
}
