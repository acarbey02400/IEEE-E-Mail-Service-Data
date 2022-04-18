using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.EmailService.Abstract;
using Core.Utilities.EmailService.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
   public class AutofacBusinessModule:Module
    {
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<CustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<CustomerManger>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<GMailServices>().As<IEmailService>().SingleInstance();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
