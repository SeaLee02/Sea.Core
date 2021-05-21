using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Api.Controllers.Sys
{
    /// <summary>
    /// 列子接口
    /// </summary>
    public class ExampleController : SysControllerBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ExampleController()
        {

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task Query([FromQuery] QueryModel model)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(AddModel model)
        {

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task Edit([BindRequired] Guid id)
        {
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update(UpdateModel model)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete([BindRequired] Guid id)
        {

        }
    }

    /// <summary>
    /// 查询Model
    /// </summary>
    public class QueryModel
    {
        public string Name { get; set; }

    }


    public class AddModel 
    {
    
    }

    public class UpdateModel 
    {
    
    }



}
