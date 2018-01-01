using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyAccount.Application;
using EmergencyAccount.Etity;
using EmergencyAccount.Etity.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Controllers.Base;
using webapi.Model;

namespace webapi.Controllers
{
    [Route("v0/antiques")]
    public class AntiquesController : BaseApiController
    {
        private readonly IAntiquesService _iAntiquesService;

        //public AccountController(EfDbContext context)
        //{
        //    accountService = new AccountService(context);
        //}
        public AntiquesController(IAntiquesService antiquesService)
        {
            _iAntiquesService = antiquesService;
        }

        /// <summary>
        /// 获得所有博物馆文物信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseModel> GetAntiques(string id)
        {
            var result = await _iAntiquesService.GetAntiquesInfoAsync(id);
            return Success(result);
        }

        /// <summary>
        /// 分页获得博物馆文物信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ResponseModel> GetPageAntiques([FromQuery]EntityAntiquesSearch entityAntiquesSearch)
        {
            var result = await _iAntiquesService.GetPageAntiquesInfoAsync(entityAntiquesSearch);
            return Success(result);
        }

        /// <summary>
        /// 保存文物信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ResponseModel> SaveAntiques([FromBody]EntityAntiques entityAntiques)
        {
            if (_iAntiquesService.GetSingleAntiquesInfoAsync(entityAntiques.Name, entityAntiques.MaxClassId) != null)
                return Fail(ErrorCodeEnum.AntiquesRepeat);
            await _iAntiquesService.AddAntiquesAsync(entityAntiques);
            return Success("保存成功");
        }

        /// <summary>
        /// 更新文物信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<ResponseModel> UpdageAntiques([FromBody]EntityAntiques entityAntiques)
        {
            await _iAntiquesService.UpdateAntiquesAsync(entityAntiques);
            return Success("保存成功");
        }
    }
}