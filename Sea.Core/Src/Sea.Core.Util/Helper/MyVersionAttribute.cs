using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util
{
    /// <summary>
    /// 版本
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class MyVersionAttribute : Attribute
    {

        public MyVersionAttribute(string _version)
        {
            this.Version = _version;
        }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
    }
}