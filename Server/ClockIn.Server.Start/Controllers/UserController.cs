using ClockIn.Server.IService;
using ClockIn.Server.Models;
using ClockIn.Server.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace ClockIn.Server.Start.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMenuService _menuService;
        ILoginService _loginService;
        IUpdateUserService _updateUserService;
        public UserController(ILoginService loginService,IMenuService menuService,IUpdateUserService updateUserService)
        {

            _loginService = loginService;
            _menuService = menuService;
            _updateUserService = updateUserService;
        }

        //登录
        //[AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login([FromForm]string userlogname, [FromForm] string password) 
        {
            string pwd = getMd5Str(getMd5Str(password)+ "|"+ userlogname);//加盐计算
            var users = _loginService.Query<SysUserInfo>(u=>u.user_login_name== userlogname&& u.user_pwd== pwd);
            if (users?.Count() > 0)
            {
                var userinfo = users.ToList();
                SysUserInfo user = userinfo[0];

                List<MenuInfo> menus=_menuService.GetMenusByRole(user.is_admin);
                user.menus = menus;
                return Ok(user);
            }
            else 
            {
                return NoContent();
            }
        }

        private string getMd5Str(string str) 
        {
            if (string.IsNullOrEmpty(str)) return "";

            byte[] res = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] outt = md5.ComputeHash(res);
            return BitConverter.ToString(outt).Replace("-", "");
        }

        [HttpPost("getall")]
        public IActionResult getall([FromForm]string isAdmin)
        {
            if (Convert.ToBoolean(isAdmin) == true) {
                var users = _updateUserService.GetAllUser();
                return Ok(users);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("getuserById")]
        public IActionResult getUser([FromForm] string id)
        {
            var user = _updateUserService.Query<SysUserInfo>(u => u.user_id == Convert.ToInt32(id));
            if (user?.Count() > 0)
            {
                var cuser = user.ToList()[0];
                return Ok(cuser);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("deleteuserById")]
        public IActionResult deleteUser([FromForm] string id)
        {
            int res = _updateUserService.deleteUserById(Convert.ToInt32(id));
            return Ok(res);
            
        }

        [HttpPost("userupdatebyid")]
        public IActionResult updateUser([FromForm] string user_json)
        {
            SysUserInfo si = JsonConvert.DeserializeObject<SysUserInfo>(user_json);
            si.user_pwd = getMd5Str(getMd5Str(si.user_pwd) + "|" + si.user_login_name);//加盐计算
            if (si != null) {
                return Ok(_updateUserService.UpdateUser(si));
            }
            return Ok(0);
        }

        [HttpPost("insert")]
        public IActionResult insertUser([FromForm]string user_json)
        {
            SysUserInfo si = JsonConvert.DeserializeObject<SysUserInfo>(user_json);
            si.user_pwd = getMd5Str(getMd5Str(si.user_pwd) + "|" + si.user_login_name);//加盐计算

            if (si != null)
            {
                return Ok(_updateUserService.Insert(si));
            }
            else 
            {
                return NoContent();
            }
        }
    }

}
