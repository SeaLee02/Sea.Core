using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sea.Core.Extensions.Filter.Swagger;
using Sea.Core.Util;
using Sea.Core.Util.Web;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Extensions
{
    /// <summary>
    /// Swagger配置
    /// </summary>
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("Sys", new OpenApiInfo { Title = "Sea.Core.Api",Version="V1", Description="描述信息" });

                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo))
                    {
                        return false;
                    }

                    IEnumerable<string> versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<MyVersionAttribute>()
                        .Select(attr => attr.Version);

                    return versions.Any(v => $"{v.ToString()}" == docName);
                });



                //转小写
                options.DocumentFilter<LowercaseDocumentFilter>();

                // 开启加权小锁
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //注释
                string xmlCommentsPath = Path.Combine(Server.BinPath, "Sea.Core.Api.xml");
                options.IncludeXmlComments(xmlCommentsPath, true);

                xmlCommentsPath = Path.Combine(Server.BinPath, "Sea.Core.Entity.xml");
                options.IncludeXmlComments(xmlCommentsPath, true);

                xmlCommentsPath = Path.Combine(Server.BinPath, "Sea.Core.Application.xml");
                options.IncludeXmlComments(xmlCommentsPath, true);

                // Jwt Bearer 认证，必须是 oauth2
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey                     
                });


            });
        }



        public static void UseSwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
                {
                    //c.RouteTemplate = "api/doc/{documentName}/swagger.json";
                });
            app.UseSwaggerUI(options =>
            {
                ///swagger/
                options.SwaggerEndpoint("/swagger/Sys/swagger.json", "基础模块");
                //指定的HTML
                //options.IndexStream = () => Assembly.GetExecutingAssembly()
                //.GetManifestResourceStream("My.D3.wwwroot.swagger.ui.Index.html");

                //启用过滤
                options.EnableFilter();
              
                //是否展开
                options.DocExpansion(DocExpansion.None);
                //model删除
                options.DefaultModelsExpandDepth(-1);
            });

        }



    }
}
