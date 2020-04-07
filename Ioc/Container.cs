using CTEP.Repositories.Impl.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Impl.Base;
using Services.Impl.Base;
using System;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace Ioc
{
    public static class Container
    {
        private static readonly string[] NotRegisterRepositoryList = new string[] { typeof(BaseRepository<BaseEntity>).Name };
        private static readonly string[] NotRegisterBusinessList = new string[] { typeof(BaseService<BaseEntity>).Name };

        public static void RegisterDbContext(this IUnityContainer container)
        {
            container.RegisterType<DbContext, CtepContext>();
        }

        public static void RegisterRepositories(this IUnityContainer container)
        {
            var repositoriesTypesToRegister = Assembly.GetAssembly(typeof(CtepContext)).GetExportedTypes().Where(type => !type.IsInterface && type.Name.EndsWith("Repository") && !NotRegisterRepositoryList.Contains(type.Name));

            foreach (var type in repositoriesTypesToRegister)
            {
                var interfaceTypeToRegisterFor = type.GetInterfaces().FirstOrDefault(thisInterface => thisInterface.Name.Contains(type.Name)) ?? type;
                container.RegisterType(interfaceTypeToRegisterFor, type,
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptor>());
            }
        }

        public static void RegisterBusiness(this IUnityContainer container)
        {
            var businessTypesToRegister = Assembly.GetAssembly(typeof(BaseService<BaseEntity>)).GetExportedTypes().Where(type => !type.IsInterface && type.Name.EndsWith("Service") && !NotRegisterBusinessList.Contains(type.Name));

            foreach (var type in businessTypesToRegister)
            {
                var interfaceTypeToRegisterFor = type.GetInterfaces().FirstOrDefault(thisInterface => thisInterface.Name.Contains(type.Name)) ?? type;
                container.RegisterType(interfaceTypeToRegisterFor, type,
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptor>());
            }
        }
    }
}
