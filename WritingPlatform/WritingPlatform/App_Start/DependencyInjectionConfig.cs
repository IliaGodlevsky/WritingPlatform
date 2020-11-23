﻿using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.Mvc;
using System.Configuration;
using System.Web.Mvc;
using WritingPlatform.Data;
using WritingPlatform.Data.Abstractions;
using WritingPlatform.Service;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.App_Start
{
    internal class DependencyInjectionConfig
    {
        public static void RegisterDependencies()
        {
            var module = new Module();
            var kernel = new StandardKernel(module);
            var resolver = new NinjectDependencyResolver(kernel);

            DependencyResolver.SetResolver(resolver);
        }

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
        }

        private static string GetDefaultConnection()
        {
            return ConfigurationManager.AppSettings.Get("defaultConnection");
        }

        private class Module : NinjectModule
        {
            public override void Load()
            {
                Bind<IDataUnitOfWork>()
                    .To<DataUnitOfWork>()
                    .InRequestScope()
                    .WithConstructorArgument("connectionString", GetDefaultConnection());

                Bind<IUserService>()
                    .To<UserService>()
                    .InRequestScope();

                Bind<ICompositionService>()
                    .To<CompositionService>()
                    .InRequestScope();

                Bind<ICommentService>()
                    .To<CommentService>()
                    .InRequestScope();

            }
        }
    }
}