﻿using System;
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
        public async Task<ResponseModel> GetPageMuseums(EntityMuseumSearch entityMuseumSearch)
        {
            var result = await _museumService.GetPageMuseumAsync(entityMuseumSearch);
            return Success(result);
        }

        /// <summary>
        /// 新增所有博物馆信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ResponseModel> AddMuseums([FromBody]EntityMuseum entityMuseum)
        {
            await _museumService.AddMuseumAsync(entityMuseum);
            return Success("保存成功");
        }
        
        /// <summary>
        /// 编辑博物馆信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<ResponseModel> EditMuseums([FromBody]EntityMuseum entityMuseum)
        {
            if (string.IsNullOrEmpty(entityMuseum.Id)) return Fail(ErrorCodeEnum.IdentifyIsNull);
            await _museumService.EditMuseumAsync(entityMuseum);
            return Success("保存成功");
        }

        /// <summary>
        /// 编辑博物馆信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("delete/{id}")]
        public async Task<ResponseModel> EditMuseums(string id)
        {
            if (string.IsNullOrEmpty(id)) return Fail(ErrorCodeEnum.IdentifyIsNull);
            await _museumService.DisableMuseumAsync(id);
            return Success("删除成功");
        }
    }
}
