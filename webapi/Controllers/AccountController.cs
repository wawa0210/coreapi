using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Controllers.Base;
using IService;
using Service;

namespace webapi.Controllers
{
    [Produces("application/json")]
    [Route("v0/accounts")]
    public class AccountController : BaseApiController
    {

        private readonly IAccountService _accountService;

        //public AccountController(EfDbContext context)
        //{
        //    accountService = new AccountService(context);
        //}
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// 获得店铺所有信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<MscAccount>> GetAccounts()
        {
            var result = await _accountService.GetAllAccounts();

            return result;
        }
    }
}