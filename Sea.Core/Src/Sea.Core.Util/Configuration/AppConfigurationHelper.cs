namespace Sea.Core.Util.Configuration
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Concurrent;
    using System.IO;

    /// <summary>
    /// 用于取appsetting.json文件的内容
    /// </summary>
    public static class AppConfigurationHelper
    {
        /// <summary>
        /// 使用appsetting.json作为配置文件
        /// 读取数据库链接字符串：AppConfigurtaionServices.Configuration.GetConnectionString("CxyOrder"); 
        /// 读取一级配置节点配置：AppConfigurtaionServices.Configuration["ServiceUrl"];
        /// 读取二级子节点配置：AppConfigurtaionServices.Configuration["Appsettings:SystemName"];
        /// </summary>
        public static IConfiguration Configuration { get; set; }


        private static readonly ConcurrentDictionary<string, IConfigurationRoot> ConfigurationCache;   //Microsoft.Extensions.Configuration

        /// <summary>
        /// Initializes static members of the <see cref="AppConfigurationHelper"/> class.
        /// 静态构造存储
        /// </summary>
        static AppConfigurationHelper()
        {
            ConfigurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="path">json文件所在的路径</param>
        /// <param name="environmentName">加环境的名称</param>
        /// <returns>配置集合</returns>
        public static IConfigurationRoot Get(string path, string environmentName = null)
        {
            string cacheKey = path + "#" + environmentName;
            return ConfigurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName)
            );
        }

        /// <summary>
        /// json路径
        /// </summary>
        /// <param name="path">jsong路径</param>
        /// <param name="environmentName">json别名</param>
        /// <returns>jison配置</returns>
        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(path)   ////Microsoft.Extensions.Configuration.FileExtensions
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);//Microsoft.Extensions.Configuration.Json   AddJsonFile

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();  //Microsoft.Extensions.Configuration.EnvironmentVariables

            return builder.Build();
        }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path"></param>
        /// <param name="environmentName"></param>
        public static void Init(string path, string environmentName = null)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
           .SetBasePath(path)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{environmentName}.json", optional: true).AddEnvironmentVariables();
            Configuration = builder.Build();
        }


    }
}