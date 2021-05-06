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
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Sea.Core.Extensions.Authorizations.Policys;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Sea.Core.Api.Controllers.Sys
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginController : SysControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly PermissionRequirement _requirement;

        private readonly IRole2Module2PermissionAppService _role2Module2PermissionAppService;

        public LoginController(IUserAppService userAppService, PermissionRequirement requirement, IRole2Module2PermissionAppService role2Module2PermissionAppService)
        {
            this._userAppService = userAppService;
            this._requirement = requirement;
            this._role2Module2PermissionAppService = role2Module2PermissionAppService;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<string>> InitData()
        {
            await this._userAppService.InitData();
            return new MessageModel<string>()
            {
                success = true,
                msg = "ok",
                response = "初始化数据成功"
            };
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

            var user = (await _userAppService.Queryable(x => x.LoginName == dto.Name && x.LoginPwd == dto.Pass)).ToList();
            if (user.Count > 0)
            {
                //基于角色授权
                var userRoles = await _userAppService.GetUserRoleNameStr(dto.Name, dto.Pass);

                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, dto.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().Id),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
                claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
                if (!Permissions.IsUseIds4)
                {
                    var data = await _role2Module2PermissionAppService.RoleModuleMaps();
                    //角色,权限 关系列表
                    var list = (from item in data
                                select new PermissionItem
                                {
                                    Url = item.ModuleEntity?.LinkUrl,
                                    Role = item.RoleEntity?.Name,
                                }).ToList();

                    _requirement.Permissions = list;
                }

                var token = JwtTokenHelper.BuildJwtToken(claims.ToArray(), _requirement);
                return new MessageModel<JwtTokenOutDto>()
                {
                    success = true,
                    msg = "获取成功",
                    response = token
                };
            }
            else
            {
                return await Task.FromResult(new MessageModel<JwtTokenOutDto>()
                {
                    success = false,
                    msg = "认证失败",
                });
            }
        }


        /// <summary>
        /// 请求刷新Token（以旧换新）
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<JwtTokenOutDto>> RefreshToken(string token = "")
        {
            string jwtStr = string.Empty;

            if (string.IsNullOrEmpty(token))
            {
                return new MessageModel<JwtTokenOutDto>()
                {
                    success = false,
                    msg = "token无效，请重新登录！",
                };
            }
            var tokenModel = JwtHelper.SerializeJwt(token);
            if (tokenModel != null && tokenModel.Uid != "")
            {
                var user = (await _userAppService.Queryable(x => x.Id == tokenModel.Uid)).FirstOrDefault();
                if (user != null)
                {
                    var userRoles = await _userAppService.GetUserRoleNameStr(user.LoginName, user.LoginPwd);
                    //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.LoginName),
                    new Claim(JwtRegisteredClaimNames.Jti, tokenModel.Uid),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
                    claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

                    //用户标识
                    var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                    identity.AddClaims(claims);

                    var refreshToken = JwtTokenHelper.BuildJwtToken(claims.ToArray(), _requirement);
                    return new MessageModel<JwtTokenOutDto>()
                    {
                        success = true,
                        msg = "获取成功",
                        response = refreshToken
                    };
                }
            }

            return new MessageModel<JwtTokenOutDto>()
            {
                success = false,
                msg = "认证失败！",
            };
        }
    }

}
