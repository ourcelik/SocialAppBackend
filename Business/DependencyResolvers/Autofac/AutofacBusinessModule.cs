using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<ProfileManager>().As<IProfileService>().SingleInstance();
            builder.RegisterType<EfProfileDal>().As<IProfileDal>().SingleInstance();
            builder.RegisterType<BankManager>().As<IBankService>().SingleInstance();
            builder.RegisterType<EfBankDal>().As<IBankDal>().SingleInstance();
            builder.RegisterType<ChatLevelManager>().As<IChatLevelService>().SingleInstance();
            builder.RegisterType<EfChatLevelDal>().As<IChatLevelDal>().SingleInstance();
            builder.RegisterType<ChoiceManager>().As<IChoiceService>().SingleInstance();
            builder.RegisterType<EfChoiceDal>().As<IChoiceDal>().SingleInstance();
            builder.RegisterType<ConstantRoomManager>().As<IConstantRoomService>().SingleInstance();
            builder.RegisterType<EfConstantRoomDal>().As<IConstantRoomDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();



        }
    }
}
