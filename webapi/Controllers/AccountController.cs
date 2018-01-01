using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using EmergencyAccount.Application;

namespace webapi.Controllers
{
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

    }
}