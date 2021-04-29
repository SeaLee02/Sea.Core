using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sea.Core.Application.AppServices.Sys.Login.Dto;
using Sea.Core.Extensions;
using Sea.Core.Util.Consts;
using Sea.Core.Util.Helper;
using Sea.Core.Util.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Sea.Core.Util;

namespace Sea.Core.Api.Controllers.Sys
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginController : SysControllerBase
    {

        public LoginController()
        {
        }


        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<MessageModel<JwtTokenOutDto>> JwtToken(JwtTokenInDto dto)
        {
            string jwt = string.Empty;


            return await Task.FromResult(new MessageModel<JwtTokenOutDto>()
            {
                msg = jwt
            });
        }

    }

}
