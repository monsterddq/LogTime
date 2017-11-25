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
            if (!ModelState.IsValid)
                return Json(new ExceptionResult("001", "Invalid data"));
            if(!IsUnique(obj))
                return Json(new ExceptionResult("002", "Duplicate Data"));
            obj.user_id = GenerateCode(PrefixUser);
            obj.password = Sha512Hash(obj.password);
            userService.Add(obj);
            return Json(new ExceptionResult("200", "Success"));
        }

        [HttpPost]
        [Route("signin")]
        public JsonResult Signin(UserSignUpLoginDTO obj)
        {
            if (!ModelState.IsValid)
                return Json(new ExceptionResult("001", "Invalid data"));
            UserDTO user = userService.FetchByEmail(obj.email) 
                        ?? userService.FetchByUserName(obj.username);
            if(user==null)
                return Json(new ExceptionResult("003", "Not found UserName or Email."));
            if(!IsMatchPassword(obj.password,user))
                return Json(new ExceptionResult("004", "Do not match password."));
            return Json(JwtManager.GenerateToken(user.user_id, user.username, user.fullname, user.email));
        }

        private bool IsUnique(UserDTO obj)
        {
            if (userService.FetchByUserName(obj.username) != null) return false;
            if (userService.FetchByEmail(obj.email) != null) return false;
            return true;
        }
        private bool IsMatchPassword(string passowrd, UserDTO user) 
            => Sha512Hash(passowrd).Equals(user.password);
    }
}