using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Framework.Middlewares
{
    public class ValidateModelMiddleware : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorFieldsAndMsgs = context.ModelState.Where(m => m.Value.Errors.Any())
                 .Select(x => new { x.Key, x.Value.Errors });

                var listErrMsg = new List<dynamic>();
                foreach (var item in errorFieldsAndMsgs)
                {
                    var ErrMsgs = new List<string>();

                    foreach (var msgItem in item.Errors)
                    {
                        //如果存在异常 暴露
                        var exceptionMsg = "";
                        if (msgItem.Exception != null)
                        {
                            exceptionMsg = msgItem.Exception.Message;
                        }
                        ErrMsgs.Add(exceptionMsg);
                    }

                    listErrMsg.Add(new { item.Key, ErrMsgs });
                }

                //返回异常信息
                context.Result = new BadRequestObjectResult(JsonConvert.SerializeObject(listErrMsg));
            }
        }
    }
}
