using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper.ExmailModel
{
    /// <summary>
    /// 邮件返回基类
    /// </summary>
    public abstract class ExmailAbstract
    {
        /// <summary>
        /// 状态码  https://exmail.qq.com/qy_mng_logic/doc#10045
        /// </summary>
        public int Errcode { get; set; }
        
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Errmsg { get; set; }
    }

    public class ExmailModel : ExmailAbstract
    {
    
    }
}
