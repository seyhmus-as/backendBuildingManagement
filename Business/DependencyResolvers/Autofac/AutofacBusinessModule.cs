using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ApartmentManager>().As<IApartmentService>().SingleInstance();
            builder.RegisterType<EfApartmentDal>().As<IApartmentDal>().SingleInstance();

            builder.RegisterType<CardManager>().As<ICardService>().SingleInstance();
            builder.RegisterType<EfCardDal>().As<ICardDal>().SingleInstance();

            builder.RegisterType<FlatManager>().As<IFlatService>().SingleInstance();
            builder.RegisterType<EfFlatDal>().As<IFlatDal>().SingleInstance();

            builder.RegisterType<RenterManager>().As<IRenterService>().SingleInstance();
            builder.RegisterType<EfRenterDal>().As<IRenterDal>().SingleInstance();

            builder.RegisterType<CardHistoryManager>().As<ICardHistoryService>().SingleInstance();
            builder.RegisterType<EfCardHistoryDal>().As<ICardHistoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
