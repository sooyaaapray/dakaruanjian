using ClockIn.Server.IService;
using ClockIn.Server.Models;
using ClockIn.Server.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ClockIn.Server.Models.ClockInState;

namespace ClockIn.Server.Start.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        IClockInService _clockInService;
        ILeaveService _leaveService;
        ICheckService _checkService;
        public LeaveController(IClockInService clockInService, ILeaveService leaveService, ICheckService checkService)
        {
            _clockInService=clockInService;
            _leaveService=leaveService;
            _checkService=checkService;
        }

        //打卡 ClockInService

        [HttpPost("clockin")]
        public IActionResult Clockin(int user_id,int code)
        {
            if (_clockInService.ClockIn(user_id, (state_Type)code) == 0) {

                return Ok();
            }return Ok();
        }

        //获取所有请假信息
        [HttpPost("getAllLeave")]
        public IActionResult getAllLeave()
        {
            _checkService.getAllLeaveInfo();
            return NoContent();
        }

        [HttpPost("AskForLeave")]
        public IActionResult AskForLeave()
        {
            _leaveService.Leave(null);
            return NoContent();
        }
        //请假 LeaveService

        [HttpPost("CheckLeave")]
        public IActionResult CheckLeave()
        {
            _checkService.approve(null);
            return NoContent();
        }
        //审批 CheckService
    }
}
