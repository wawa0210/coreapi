using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using webapi.Model;
using EmergencyAccount.Etity;
using EmergencyAccount.Application;
using webapi.Controllers.Base;
using CommonLib;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Drawing;

namespace webapi.Controllers
{
    [Route("v0/auth")]
    public class AuthController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 获得token 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public async Task<ResponseModel> GetAccountAuth([FromBody]EntityLoginModel loginModel)
        {
            var result = await _accountService.GetAccountManagerSync(loginModel.UserName);

            if (result == null) return Fail(ErrorCodeEnum.UserIsNull);

            var checkResult = _accountService.CheckLoginInfo(loginModel.UserPwd, result.UserSalt, result.UserPwd);
            if (!checkResult) return Fail(ErrorCodeEnum.UserPwdCheckFaild);
            return Success(new
            {
                token = AesHelper.Encrypt(JsonConvert.SerializeObject(result)),
                userInfo = result
            });
        }
    }

    public class TokenRequest
    {
        [Required(ErrorMessage = "店铺编号不能为空")]
        public int AccId
        {
            get; set;
        }
    }
}