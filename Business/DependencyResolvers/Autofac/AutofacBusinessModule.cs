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
using Core.Utilities.Security.JWT;

namespace Business.DependencyResolvers.Autofac
{
   public  class AutofacBusinessModule:Module
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
            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>().SingleInstance();
            builder.RegisterType<PreferManager>().As<IPreferService>().SingleInstance();
            builder.RegisterType<EfPreferDal>().As<IPreferDal>().SingleInstance();
            builder.RegisterType<NotificationManager>().As<INotificationService>().SingleInstance();
            builder.RegisterType<EfNotificationDal>().As<INotificationDal>().SingleInstance(); 
            builder.RegisterType<RankManager>().As<IRankService>().SingleInstance();
            builder.RegisterType<EfRankDal>().As<IRankDal>().SingleInstance();
            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>().SingleInstance(); 
            builder.RegisterType<PhotoManager>().As<IPhotoService>().SingleInstance();
            builder.RegisterType<EfPhotoDal>().As<IPhotoDal>().SingleInstance();
            builder.RegisterType<MatchManager>().As<IMatchService>().SingleInstance();
            builder.RegisterType<EfMatchDal>().As<IMatchDal>().SingleInstance();
            builder.RegisterType<LikeKindManager>().As<ILikeKindService>().SingleInstance();
            builder.RegisterType<EfLikeKindDal>().As<ILikeKindDal>().SingleInstance();
            builder.RegisterType<LikedManager>().As<ILikedService>().SingleInstance();
            builder.RegisterType<EfLikedDal>().As<ILikedDal>().SingleInstance();
            builder.RegisterType<ProfileQuestionManager>().As<IProfileQuestionService>().SingleInstance();
            builder.RegisterType<EfProfileQuestionDal>().As<IProfileQuestionDal>().SingleInstance();
            builder.RegisterType<ConstantRoomMemberManager>().As<IConstantRoomMemberService>().SingleInstance();
            builder.RegisterType<EfCRMemberDal>().As<ICrMemberDal>().SingleInstance();
            builder.RegisterType<RoomMemberManager>().As<IRoomMemberService>().SingleInstance();
            builder.RegisterType<EfRMemberDal>().As<IRMemberDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();



        }
    }
}
