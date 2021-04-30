using Sea.Core.Util.Consts;
using Sea.Core.Util.Extensions;
using Sea.Core.Util.Helper;
using Sea.Core.Util.Helper.ExmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sea.Core.Util
{
    /// <summary>
    /// 邮件帮助类,依赖注入使用
    /// </summary>
    public class ExmailHelper
    {
        /// <summary>
        /// token数据
        /// </summary>
        public string Email_token
        {
            get
            {
                return Token().Result;
            }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Errmsg { get; set; }

        private readonly ICaching _cache;
        public ExmailHelper(ICaching caching)
        {
            _cache = caching;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> Token()
        {
            string Email_token = this._cache.Get<string>(CacheAppConsts.ExmailToken);
            if (Email_token == null)
            {
                //Email_token = Guid.NewGuid().ToString();
                //this._cache.Set(CacheAppConsts.ExmailToken, Email_token, 10);

                //配置中心        
                string url = $"https://api.exmail.qq.com/cgi-bin/gettoken?corpid={CacheAppConsts.Corpid}&corpsecret={CacheAppConsts.Corpsecret}";
                TokenModel model = await HttpHelper.GetHttpAsync<TokenModel>(url);
                if (model.Errcode != 0)
                {
                    this.Errmsg = model.Errmsg;
                    throw new Exception($"获取企业邮件Token失败:{model.Errcode}-{this.Errmsg}");
                }
                Email_token = model.Access_Token;
                this._cache.Set(CacheAppConsts.ExmailToken, Email_token, model.Expires_In);
            }
            return await Task.FromResult(Email_token);
        }


        #region 部门
        /// <summary>
        /// 获取部门(指定部门以及子部门)
        /// </summary>
        /// <param name="departmenId">需要获取的部门</param>
        /// <returns></returns>
        public async Task<DepartmentListModel> GetDepartment(int? departmenId = null)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/department/list?access_token={this.Email_token}";
            if (!departmenId.IsNotEmptyOrNull())
            {
                url += $"&id={departmenId}";
            }
            DepartmentListModel model = await HttpHelper.GetHttpAsync<DepartmentListModel>(url);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"获取获取部门失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CreateDepartmentModel> CreateDepartment(CreateDepartmentDto dto)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/department/create?access_token={this.Email_token}";
            CreateDepartmentModel model = await HttpHelper.PostHttpAsync<CreateDepartmentModel, CreateDepartmentDto>(url, dto);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"创建部门失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ExmailModel> UpdateDepartment(UpdateDepartmentDto dto)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/department/update?access_token={this.Email_token}";
            ExmailModel model = await HttpHelper.PostHttpAsync<ExmailModel, UpdateDepartmentDto>(url, dto);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"创建部门失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"> 部门id。（注：不能删除根部门；不能删除含有子部门、成员的部门）</param>
        /// <returns></returns>
        public async Task<ExmailModel> DelDepartment(long id)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/department/delete?access_token={this.Email_token}&id={id}";
            ExmailModel model = await HttpHelper.GetHttpAsync<ExmailModel>(url);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"删除部门失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }



        #endregion

        #region 成员
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ExmailModel> CreateUser(CreateUserModel dto)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/user/create?access_token={this.Email_token}";
            ExmailModel model = await HttpHelper.PostHttpAsync<ExmailModel, CreateUserModel>(url, dto);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"创建用户失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="departmenId">需要获取的部门</param>
        /// <returns></returns>
        public async Task<ExmailModel> UpdateUser(CreateUserModel dto)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/user/update?access_token={this.Email_token}";
            ExmailModel model = await HttpHelper.PostHttpAsync<ExmailModel, CreateUserModel>(url, dto);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"更新用户失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户UserId</param>
        /// <returns></returns>
        public async Task<ExmailModel> DelUser(string userId)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/user/delete?access_token={this.Email_token}&userid={userId}";
            ExmailModel model = await HttpHelper.GetHttpAsync<ExmailModel>(url);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"删除用户失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userId">用户UserId</param>
        /// <returns></returns>
        public async Task<ExmailModel> GetUser(string userId)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/user/get?access_token={this.Email_token}&userid={userId}";
            UserModel model = await HttpHelper.GetHttpAsync<UserModel>(url);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"获取用户失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }
        #endregion

        #region 邮件组
        /// <summary>
        /// 创建邮组
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<GroupModel> CreateGroup(CreateGroupModel dto)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/group/create?access_token={this.Email_token}";
            GroupModel model = await HttpHelper.PostHttpAsync<GroupModel, CreateGroupModel>(url, dto);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"创建邮箱组失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }


        /// <summary>
        /// 更新邮组
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<GroupModel> UpdateGroup(CreateGroupModel dto)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/group/update?access_token={this.Email_token}";
            GroupModel model = await HttpHelper.PostHttpAsync<GroupModel, CreateGroupModel>(url, dto);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"更新邮箱组失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 删除邮组
        /// </summary>
        /// <param name="userId">用户UserId</param>
        /// <returns></returns>
        public async Task<ExmailModel> DelGroup(string groupid)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/group/delete?access_token={this.Email_token}&groupid={groupid}";
            ExmailModel model = await HttpHelper.GetHttpAsync<ExmailModel>(url);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"删除邮组失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        /// <summary>
        /// 获取邮组
        /// </summary>
        /// <param name="userId">用户UserId</param>
        /// <returns></returns>
        public async Task<GroupInfoModel> GetGroup(string groupid)
        {
            string url = $"https://api.exmail.qq.com/cgi-bin/group/get?access_token={this.Email_token}&groupid={groupid}";
            GroupInfoModel model = await HttpHelper.GetHttpAsync<GroupInfoModel>(url);
            if (model.Errcode != 0)
            {
                this.Errmsg = model.Errmsg;
                throw new Exception($"获取用户失败:{model.Errcode}-{this.Errmsg}");
            }
            return await Task.FromResult(model);
        }

        #endregion


    }
}
