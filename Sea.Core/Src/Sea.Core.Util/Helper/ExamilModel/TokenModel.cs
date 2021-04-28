using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper.ExamilModel
{
    /// <summary>
    /// 获取token
    /// </summary>
    public class TokenModel
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        /// <summary>
        /// token值
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 过期时间,秒
        /// </summary>
        public int expires_in { get; set; }
    }
}
