using ClockIn.Client.IBLL;
using ClockIn.Client.IDAL;

namespace ClockIn.Client.BLL
{
    public class GetAllMessageBll : IGetAllMessageBll
    {
        IGetAllMessageDAL _iGetAllMessageDAL;
        public GetAllMessageBll(IGetAllMessageDAL iGetAllMessageDAL)
        {
            _iGetAllMessageDAL = iGetAllMessageDAL;
        }
        public Task<string> getAllMessage()
        {
            throw new NotImplementedException();
        }
    }
}
