using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper.ExmailModel
{
    /// <summary>
    /// 获取token
    /// </summary>
    public class TokenModel: ExmailModel
    {
    
        /// <summary>
        /// token值
        /// </summary>
        public string Access_Token { get; set; }
        /// <summary>
        /// 过期时间,秒
        /// </summary>
        public int Expires_In { get; set; }
    }
}
