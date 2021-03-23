using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Web
{
    /// <summary>
    /// 网站服务器帮助泪
    /// </summary>
    public static class Server
    {
        /// <summary>
        /// bin的目录地址
        /// </summary>
        public static string BinPath => AppContext.BaseDirectory;

        /// <summary>
        /// 网站的根路径(在start.cs中设置) 测试默认就是basedirectory
        /// </summary>
        public static string ContentRootPath { get; set; } = Directory.GetCurrentDirectory();

        /// <summary>
        /// 兼容mvc的MapPath
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns>路径的值</returns>
        public static string MapPath(string virtualPath)
        {
            string wwwRootPath = ContentRootPath + @"\wwwroot\";
            if (virtualPath == null)
            {
                return null;
            }
            else if (virtualPath.StartsWith("~/"))
            {
                return virtualPath.Replace("~/", wwwRootPath);
            }
            else if (virtualPath.StartsWith(@"~\"))
            {
                return virtualPath.Replace(@"~\", wwwRootPath);
            }
            else
            {
                return Path.Combine(wwwRootPath, virtualPath);
            }
        }

        /// <summary>
        /// httpContext
        /// </summary>
        public static HttpContext HttpContext
        {
            get
            {
                HttpContext context = new DefaultHttpContext();
                return context;
            }
        }
    }
}
