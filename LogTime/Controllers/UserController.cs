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

namespace LogTime.Controllers
{
    [ResponseCache(CacheProfileName = "LogTime")]
    [Route("api/user")]
    public class UserController : Controller
    {
        private UserService userService;
        public UserController() => userService = new UserService();
        [Route("login")]
        [HttpPost]
        public JsonResult Login(UserDTO obj)
        {
            var user = userService.FetchByUserName(obj.username);
            if (user.password.Equals(Utility.Utility.Sha512Hash(obj.password)))
                return Json(JwtManager.GenerateToken(user.user_id, user.username, user.fullname, user.email));
            else
                return Json(new ExceptionResult("401", "account or password is incorrect"));
        }

        [Route("details")]
        [HttpGet]
        [Authorize]
        public JsonResult GetCurrentUser()
        {
            return Json("asdf");
        }
        //=> Json(userService.FetchByKey(User.Claims.FirstOrDefault().Value));

    }
}