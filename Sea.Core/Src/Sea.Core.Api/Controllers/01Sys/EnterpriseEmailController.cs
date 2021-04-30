using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea.Core.Util;
using Sea.Core.Util.Helper.ExmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Api.Controllers.Sys
{
    /// <summary>
    /// 企业邮箱测试
    /// </summary>
    public class EnterpriseEmailController : SysControllerBase
    {

        private readonly ExmailHelper _exmailHelper;
        public EnterpriseEmailController(ExmailHelper exmailHelper)
        {
            this._exmailHelper = exmailHelper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetTest(CreateGroupModel dto)
        {
            Console.WriteLine("---------------");
            dto.Department[0] = 5394703153207343904;
             var dd = await _exmailHelper.UpdateGroup(dto);
            return new JsonResult(dd);

        }

    }
}