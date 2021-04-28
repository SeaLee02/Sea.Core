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

        private readonly ExmailHelper _exmailHelper;
        public LoginController(ExmailHelper exmailHelper)
        {
            _exmailHelper = exmailHelper;
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
            await _exmailHelper.Token();



            //string email_token = this._cache.Get<string>(CacheAppConsts.ExmailToken);
            //if (email_token == null)
            //{
            //    string corpid = "wmb0da26b85b9e8d69", corpsecret = "belBnFETVsjiEJ2304IGe61vUCeyiTP7ULP-Wvr0yLz1rFvkqK5JbM6RQ4x-R2dx";
            //    string getTokenUrl = $"https://api.exmail.qq.com/cgi-bin/gettoken?corpid={corpid}&corpsecret={corpsecret}";
            //     var result= await HttpHelper.GetAsync(getTokenUrl);

            //    dynamic dy = JsonSerializer.Deserialize<dynamic>(result);
            //    this._cache.Set(CacheAppConsts.ExmailToken, dy.access_token, dy.expires_in);
            //}

            string jwt = string.Empty;


            return await Task.FromResult(new MessageModel<JwtTokenOutDto>()
            {
                msg = _exmailHelper.Email_token
            });
        }

    }

}
