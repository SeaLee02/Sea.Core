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
            #region ���ð�����
            //ע��Ϊ����ģʽ
            services.AddSingleton(new Appsettings(Configuration));
            //���ӣ�
            //bool a=  Appsettings.app(new string[] { "Startup", "IdentityServer4", "Enabled" }).ObjToBool();
            //Appsettings.app<MutiDBOperate>("DBS")
            #endregion

            Permissions.IsUseIds4 = Appsettings.app(new string[] { "Startup", "IdentityServer4", "Enabled" }).ObjToBool();



            // ȷ������֤���ķ��ص�ClaimType�������ģ���ʹ��Mapӳ��
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //�ڴ滺��
            services.AddMemoryCacheSetup();
            //��Ҫ�����ڻ������,����ע��ʹ��,��ҵ�ʼ�������,����ע��ʹ��
            services.AddSingleton<ExmailHelper>();


            //Redis����
            //services.AddRedisCacheSetup();



            //ע�������ģ�������ע�룬1:������2���رմ�λ�ӣ���AutofacModuleRegister�����ע��������
            //�������й��캯���Ĳ�����Ҫע�룬���������Ҳ��Ҫ��(todo) //SimpleDbContextProvider��������ע��,����ʵ����;
            services.AddScoped<IDbContextProvider<MyDbContext>, SimpleDbContextProvider<MyDbContext>>();

            #region ���ݿ�����
            string path = Configuration.GetConnectionString("MySQLConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<MyDbContext>(options =>
            {
                //��ӡSQL���
                //options.LogTo(Console.WriteLine);
                options.UseSqlServer(path, sql => sql.MigrationsAssembly(migrationsAssembly));
                //options.UseMySQL(path);
            });
            #endregion


            //mapper ӳ��
            services.AddAutoMapperSetup();

            //��Ȩ���Զ�����Ȩ
            services.AddAuthorizationSetup();
            if (Permissions.IsUseIds4)
            {
                //ids4��֤
                services.AddAuthenticationIds4Setup();
            }
            else
            {
                //Jwt
                services.AddAuthentication_JWTSetup();
            }        


            //�ر��Զ���֤
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //��ӿ�����                      
            services.AddControllers(o =>
            {
                //���Dto��֤
                o.Filters.Add<ModelActionFilte>();

                // ȫ���쳣����
                //o.Filters.Add(typeof(GlobalExceptionsFilter));

            }).AddNewtonsoftJson(options =>
            {                
                //����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //��ʹ���շ���ʽ��key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //����ʱ���ʽ
                //options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                //����Model��Ϊnull������
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                //���ñ���ʱ�����UTCʱ��
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            });
            //Swagger����
            services.AddSwaggerSetup();


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sea.Core.Api", Version = "v1" });
            //});



            //Apollo:��������
            //consul:������
        }

        // ע����Program.CreateHostBuilder�����Autofac���񹤳�
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Console.WriteLine("b");
            //����ע��
            builder.RegisterModule(new AutofacModuleRegister());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Swagger����
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
            //        //һ���Ѿ���ʼ������������޸���Ӧͷ������
            //    }
            //    await context.Response.WriteAsync("Hello2");
            //});

            app.UseRouting();

            // �ȿ�����֤
            app.UseAuthentication();
            // Ȼ������Ȩ�м��
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
