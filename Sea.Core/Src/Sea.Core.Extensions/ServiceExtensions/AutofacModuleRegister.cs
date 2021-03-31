using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Sea.Core.Application.Abstractions;
using Sea.Core.Application.Abstractions.Repositories;
using Sea.Core.Application.Abstractions.Repositories.Base;
using Sea.Core.Entity;
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
            ////注册上下文

            //builder.RegisterType<IMapper>();
            //builder.RegisterType<IDbContextProvider<MyDbContext>>();

            builder.RegisterType<MyDbContext>().InstancePerLifetimeScope();

            //builder.RegisterType<SimpleDbContextProvider<MyDbContext>>().As<IDbContextProvider<MyDbContext>>().InstancePerLifetimeScope();
          
            builder.RegisterAssemblyTypes(Assembly.Load("Sea.Core.Application"))
                 .AsImplementedInterfaces()
                 .AsSelf()
                 .InstancePerLifetimeScope();



  //          var assemblysServices = Assembly.Load("Sea.Core.Application");

  //          ////注册上下文
  //          builder.RegisterType<SimpleDbContextProvider<MyDbContext>>().As<IDbContextProvider<MyDbContext>>()
  //              .InstancePerDependency();

  //          //builder.RegisterGeneric(typeof(RepositoriesBase<,,,,,>)).As(typeof(IRepositoriesBase<,,,,,>)).InstancePerDependency();//注册仓储
  //          //builder.RegisterGeneric(typeof(RepositoriesBase<,,,,,>)).As(typeof(IRepositoriesBase<,,,,,>)).InstancePerDependency();//注册仓储
            
  ////builder.RegisterGeneric(typeof(IAppServicesBase<,,,,,>)).As(typeof(IAppServicesBase<,,,,,>)).InstancePerDependency();//注册仓储

  //          builder.RegisterAssemblyTypes(assemblysServices)
  //                    .AsImplementedInterfaces()
  //                    .InstancePerDependency();

                      //.EnableInterfaceInterceptors();//引用Autofac.Extras.DynamicProxy;
                  


         
         
        }
    }
}
