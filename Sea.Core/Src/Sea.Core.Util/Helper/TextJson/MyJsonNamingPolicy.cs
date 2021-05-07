using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper
{
    /// <summary>
    /// json自定义转换规则
    /// </summary>
    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            name.ToLower();
    }
}