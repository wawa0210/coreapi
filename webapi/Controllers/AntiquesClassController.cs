using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyAccount.Application;
using EmergencyAccount.Enum;
using EmergencyAccount.Etity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Controllers.Base;
using webapi.Model;

namespace webapi.Controllers
{
    [Route("v0/antiquesclass")]
    public class AntiquesClassController : BaseApiController
    {
        private readonly IAntiquesClassService _iAntiquesClassService;

        public AntiquesClassController(IAntiquesClassService iAntiquesClassService)
        {
            _iAntiquesClassService = iAntiquesClassService;
        }

        /// <summary>
        /// 获得所有博物馆分类信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseModel> GetAntiquesClass(string id)
        {
            var result = await _iAntiquesClassService.GetAntiquesClassAsync(id);
            return Success(result);
        }

        /// <summary>
        /// 获得所有博物馆分类信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ResponseModel> GetAllAntiquesClass()
        {
            var result = await _iAntiquesClassService.GetListAntiquesClassAsync();
            return Success(result);
        }

        /// <summary>
        /// 更新所有博物馆分类信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<ResponseModel> UpdateAntiquesClass([FromBody]EntityAntiquesClass entityAntiquesClass)
        {
            if (entityAntiquesClass.ClassLevel == (int)EnumAntiquesClassLevel.SubLevel && string.IsNullOrEmpty(entityAntiquesClass.ParentId))
                return Fail(ErrorCodeEnum.AntiquesClassError);

            await _iAntiquesClassService.UpdateAntiquesClassAsync(entityAntiquesClass);
            return Success("更新成功");
        }

        /// <summary>
        /// 添加所有博物馆分类信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ResponseModel> AddAntiquesClass([FromBody]EntityAntiquesClass entityAntiquesClass)
        {
            if (entityAntiquesClass.ClassLevel == (int)EnumAntiquesClassLevel.SubLevel && string.IsNullOrEmpty(entityAntiquesClass.ParentId))
                return Fail(ErrorCodeEnum.AntiquesClassError);
            await _iAntiquesClassService.AddAntiquesClassAsync(entityAntiquesClass);
            return Success("添加成功");
        }
    }
}