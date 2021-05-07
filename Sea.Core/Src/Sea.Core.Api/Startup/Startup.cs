using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sea.Core.Application.Abstractions.Repositories;
using Sea.Core.Entity;
using Sea.Core.Extensions;
using Sea.Core.Extensions.Filter;
using Sea.Core.Util;
using Sea.Core.Util.Configuration;
using Sea.Core.Util.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sea.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 配置帮助类
            //注册为单例模式
            services.AddSingleton(new Appsettings(Configuration));
            //例子：
            //bool a=  Appsettings.app(new string[] { "Startup", "IdentityServer4", "Enabled" }).ObjToBool();
            //Appsettings.app<MutiDBOperate>("DBS")
            #endregion

            Permissions.IsUseIds4 = Appsettings.app(new string[] { "Startup", "IdentityServer4", "Enabled" }).ObjToBool();



            // 确保从认证中心返回的ClaimType不被更改，不使用Map映射
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //内存缓存
            services.AddMemoryCacheSetup();
            //需要配置在缓存后面,依赖注入使用,企业邮件帮助类,依赖注入使用
            services.AddSingleton<ExmailHelper>();


            //Redis缓存
            //services.AddRedisCacheSetup();



            //注册上下文，单独的注入，1:开启。2：关闭此位子，打开AutofacModuleRegister里面的注册上下文
            //上下文中构造函数的参数需要注入，后面的事物也需要的(todo) //SimpleDbContextProvider用来依赖注册,不做实际用途
            services.AddScoped<IDbContextProvider<MyDbContext>, SimpleDbContextProvider<MyDbContext>>();

            #region 数据库连接
            string path = Configuration.GetConnectionString("MySQLConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<MyDbContext>(options =>
            {
                //打印SQL语句
                //options.LogTo(Console.WriteLine);
                options.UseSqlServer(path, sql => sql.MigrationsAssembly(migrationsAssembly));
                //options.UseMySQL(path);
            });
            #endregion


            //mapper 映射
            services.AddAutoMapperSetup();

            //授权，自定义授权
            services.AddAuthorizationSetup();
            if (Permissions.IsUseIds4)
            {
                //ids4验证
                services.AddAuthenticationIds4Setup();
            }
            else
            {
                //Jwt
                services.AddAuthentication_JWTSetup();
            }        


            //关闭自动验证
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //添加控制器                      
            services.AddControllers(o =>
            {
                //添加Dto验证
                o.Filters.Add<ModelActionFilte>();

                // 全局异常过滤
                //o.Filters.Add(typeof(GlobalExceptionsFilter));

            }).AddNewtonsoftJson(options =>
            {                
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                //忽略Model中为null的属性
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                //设置本地时间而非UTC时间
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            });
            //Swagger中心
            services.AddSwaggerSetup();


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sea.Core.Api", Version = "v1" });
            //});



            //Apollo:配置中心
            //consul:服务发现
        }

        // 注意在Program.CreateHostBuilder，添加Autofac服务工厂
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Console.WriteLine("b");
            //依赖注入
            builder.RegisterModule(new AutofacModuleRegister());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Swagger配置
                app.UseSwaggerConfigure();
            }

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello2");
            //});


            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("Hello");
            //    await next();
            //    if (context.Response.HasStarted)
            //    {
            //        //一旦已经开始输出，则不能再修改响应头的内容
            //    }
            //    await context.Response.WriteAsync("Hello2");
            //});

            app.UseRouting();

            // 先开启认证
            app.UseAuthentication();
            // 然后是授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "areas", "areas",
                    pattern: "api/{area:exists}/{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
