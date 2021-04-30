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
using Sea.Core.Application.AppServices.Sys;

namespace Sea.Core.Api.Controllers.Sys
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginController : SysControllerBase
    {
        private readonly IUserAppService _userAppService;        
        public LoginController(IUserAppService userAppService)
        {
            this._userAppService = userAppService;
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
            dto.Pass = MD5Helper.MD5Encrypt32(dto.Pass);


            //var user = await _userAppService.get;

            return await Task.FromResult(new MessageModel<JwtTokenOutDto>()
            {
                msg = jwt
            });
        }

    }

}
