namespace My.D3.DataAccess.Framework.Configuration
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 数据初始化帮助类
    /// </summary>
    public static class ViewConfiguration
    {
        /// <summary>
        /// 对应的view的类型后面用于反射
        /// </summary>
        public static List<string> ViewFullNames { get; set; } = new List<string>();

        /// <summary>
        /// 初始化视图
        /// </summary>
        /// <param name="entityType">ebitty的类型</param>
        public static void InitViews(IMutableEntityType entityType)
        {
            if (entityType.ClrType.FullName.ToLower().Contains("view"))
            {
                ViewFullNames.Add(entityType.ClrType.FullName + "," + entityType.ClrType.Assembly.GetName().Name);
            }

        }
    }
}
