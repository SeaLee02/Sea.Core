using Sea.Core.Util.Configuration;
using Sea.Core.Util.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Consts
{
    /// <summary>
    /// 缓存常量
    /// </summary>
    public class CacheAppConsts
    {
        /// <summary>
        /// 用户缓存
        /// </summary> 
        public static string ExmailToken { get; private set; } = "ExmailToken";


        /// <summary>
        /// KEY
        /// </summary> 
        public static string Corpid { get; private set; } = Appsettings.app(new string[] { "Email", "corpid" });

        /// <summary>
        /// Corpsecret
        /// </summary> 
        public static string Corpsecret { get; private set; } = Appsettings.app(new string[] { "Email", "corpsecret" });

    }
}
