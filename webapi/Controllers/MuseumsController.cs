using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyAccount.Application;
using EmergencyAccount.Etity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Controllers.Base;
using webapi.Model;

namespace webapi.Controllers
{
    [Route("v0/museums")]
    public class MuseumsController : BaseApiController
    {
        private readonly IMuseumService _museumService;

        public MuseumsController(IMuseumService museumService)
        {
            _museumService = museumService;
        }

        /// <summary>
        /// 获得所有博物馆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ResponseModel> GetAllMuseums()
        {
            var result = await _museumService.GetAllMuseumAsync();
            return Success(result);
        }

        /// <summary>
        /// 获得所有博物馆信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ResponseModel> AddMuseums([FromBody]EntityMuseum entityMuseum)
        {
            await _museumService.AddMuseumAsync(entityMuseum);
            return Success("保存成功");
        }
    }
}
