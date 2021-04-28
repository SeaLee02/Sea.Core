using Newtonsoft.Json;
using Sea.Core.Util.Consts;
using Sea.Core.Util.Helper;
using Sea.Core.Util.Helper.ExamilModel;
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
    public  class ExmailHelper
    {
        /// <summary>
        /// token数据
        /// </summary>
        public  string Email_token { get; set; }

        private readonly ICaching _cache;
        public ExmailHelper(ICaching caching)
        {
            _cache = caching;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        public  async Task Token() 
        {
            this.Email_token = this._cache.Get<string>(CacheAppConsts.ExmailToken);
            if (this.Email_token == null)
            {
                //配置中心        
                string getTokenUrl = $"https://api.exmail.qq.com/cgi-bin/gettoken?corpid={CacheAppConsts.Corpid}&corpsecret={CacheAppConsts.Corpsecret}";
                var result = await HttpHelper.GetAsync(getTokenUrl);
                TokenModel model = System.Text.Json.JsonSerializer.Deserialize<TokenModel>(result);
                this.Email_token = model.access_token;
                this._cache.Set(CacheAppConsts.ExmailToken, model.access_token, model.expires_in);
            }

        }


        #region 部门

        #endregion

        #region 成员

        #endregion

        #region 邮件组

        #endregion


    }
}
