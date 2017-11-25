using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogTime.DTO;
using LogTime.Services;
using LogTime.Models;
using LogTime.Config;
using LogTime.CustomException;
using Microsoft.AspNetCore.Authorization;
using static LogTime.Utility.Utility;
using static LogTime.Utility.Constant;

namespace LogTime.Controllers
{
    [ResponseCache(CacheProfileName = "LogTime")]
    [Route("api/user")]
    public class UserController : Controller
    {
        private UserService userService;
        public UserController() => userService = new UserService();
        [HttpPost]
        [Route("login")]
        public JsonResult Login(UserDTO obj)
        {
            var user = userService.FetchByUserName(obj.username);
            if (user.password.Equals(Utility.Utility.Sha512Hash(obj.password)))
                return Json(JwtManager.GenerateToken(user.user_id, user.username, user.fullname, user.email));
            else
                return Json(new ExceptionResult("401", "account or password is incorrect"));
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public JsonResult GetCurrentUser()
        {
            return Json("asdf");
        }

        [HttpPost]
        [Route("signup")]
        public JsonResult Signup(UserDTO obj)
        {
            
            if (ModelState.IsValid)
            {
                if(!IsUnique(obj))
                    return Json(new ExceptionResult("002", "Duplicate Data"));
                obj.user_id = GenerateCode(PrefixUser);
                userService.Add(obj);
                return Json(new ExceptionResult("200", "Success"));
            }
            else return Json(new ExceptionResult("001", "Invalid data"));
        }

        private bool IsUnique(UserDTO obj)
        {
            if (userService.FetchByUserName(obj.username) != null) return false;
            if (userService.FetchByEmail(obj.email) != null) return false;
            return true;
        }

    }
}