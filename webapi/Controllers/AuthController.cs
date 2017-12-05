using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace webapi.Controllers
{
    [Produces("application/json")]
    [Route("v0/auth")]
    public class AuthController : Controller
    {
        /// <summary>
        /// 获得店铺所有信息
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("token")]
        [AllowAnonymous]
        public async Task<string> RequestToken([FromBody]TokenRequest request)
        {
            //var result = await "";
            if (ModelState.IsValid)
            {
                return "";
            }
            return "false";
        }
    }

    public class TokenRequest
    {
        [Required(ErrorMessage = "店铺编号不能为空")]
        public int AccId
        {
            get;set;
        }
    }
}