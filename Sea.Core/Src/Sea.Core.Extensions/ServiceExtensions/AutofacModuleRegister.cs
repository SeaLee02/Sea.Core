using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Sea.Core.Application.Abstractions;
using Sea.Core.Application.Abstractions.Repositories;
using Sea.Core.Entity;
using Sea.Core.Extensions.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Extensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
             //注册AOP拦截器
             builder.RegisterType<LogAOP>();
            builder.RegisterAssemblyTypes(Assembly.Load("Sea.Core.Application"))
                 .AsImplementedInterfaces()                 
                .InstancePerDependency().InterceptedBy(typeof(LogAOP)).EnableClassInterceptors();//启用动态代理
            ////注册上下文，或者在start里面进行注册
            //builder.RegisterType<SimpleDbContextProvider<MyDbContext>>().As<IDbContextProvider<MyDbContext>>().InstancePerDependency();







        }
    }
}
