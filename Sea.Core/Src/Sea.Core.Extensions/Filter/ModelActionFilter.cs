using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sea.Core.Util.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Extensions.Filter
{
    /// <summary>
    /// 模型验证器
    /// </summary>
    public class ModelActionFilte : IActionFilter
    {

        // ActionFilterAttribute 


        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("模型验证完成");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("正在模型验证");
            if (!context.ModelState.IsValid)
            {

                //获取验证失败的模型字段
                var errors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new ErrorModel { Key = e.Key, Value = e.Value.Errors.First().ErrorMessage })
                    .ToList();

                var result = new MessageModel<List<ErrorModel>>()
                {
                    success = false,
                    msg = "模型验证错误",
                    response = errors
                };
                context.Result = new JsonResult(result);

            }
        }
    }


    public class ErrorModel 
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
