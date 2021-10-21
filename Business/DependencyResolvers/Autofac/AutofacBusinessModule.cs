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
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace Business.DependencyResolvers.Autofac
{
   public  class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            UserTableRegister(builder);

            ProfileTableRegister(builder);

            BankTableRegister(builder);

            ChatLevelTableRegister(builder);

            ChoiceTableRegister(builder);

            ConstantRoomTableRegister(builder);

            QuestionTableRegister(builder);

            PreferTableRegister(builder);

            NotificationTableRegister(builder);

            RankTableRegister(builder);

            RoomTableRegister(builder);

            PhotoTableManager(builder);

            MatchTableRegister(builder);

            LikeKindTableRegister(builder);

            LikeTableRegister(builder);

            ProfileQuestionTableRegister(builder);

            ConstantRoomMemberTableRegister(builder);

            RoomMemberTableRegister(builder);

            AuthSystemRegister(builder);

            AutoMapperRegister(builder);

            PostCommentServiceRegister(builder);

            PostServiceRegister(builder);

            PostInfoServiceRegister(builder);

            PostLikeServiceRegister(builder);


            UserNotificationServiceRegister(builder);



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();




        }


        private void UserNotificationServiceRegister(ContainerBuilder builder)
        {
            builder.RegisterType<UserNotificationManager>().As<IUserNotificationService>().SingleInstance();
            builder.RegisterType<EfUserNotificationDal>().As<IUserNotificationDal>().SingleInstance();
            builder.RegisterType<EfCommentNotificationDal>().As<ICommentNotificationDal>().SingleInstance();
        }

        private static void AutoMapperRegister(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
            
            
        }

        private static void AuthSystemRegister(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }

        private static void PostServiceRegister(ContainerBuilder builder)
        {
            builder.RegisterType<PostManager>().As<IPostService>().SingleInstance();
            builder.RegisterType<EfPostDal>().As<IPostDal>();
        }
        private static void PostInfoServiceRegister(ContainerBuilder builder)
        {
            builder.RegisterType<PostInfoManager>().As<IPostInfoService>().SingleInstance();
            builder.RegisterType<EfPostInfoDal>().As<IPostInfoDal>();
        }
        private static void PostLikeServiceRegister(ContainerBuilder builder)
        {
            builder.RegisterType<PostLikeManager>().As<IPostLikeService>().SingleInstance();
            builder.RegisterType<EfPostLikeDal>().As<IPostLikeDal>();
        }
        private static void PostCommentServiceRegister(ContainerBuilder builder)
        {
            builder.RegisterType<PostCommentManager>().As<IPostCommentService>().SingleInstance();
            builder.RegisterType<EfPostCommentDal>().As<IPostCommentDal>();
        }

        private static void RoomMemberTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<RoomMemberManager>().As<IRoomMemberService>().SingleInstance();
            builder.RegisterType<EfRMemberDal>().As<IRMemberDal>().SingleInstance();
        }

        private static void ConstantRoomMemberTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<ConstantRoomMemberManager>().As<IConstantRoomMemberService>().SingleInstance();
            builder.RegisterType<EfCRMemberDal>().As<ICrMemberDal>().SingleInstance();
        }

        private static void ProfileQuestionTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<ProfileQuestionManager>().As<IProfileQuestionService>().SingleInstance();
            builder.RegisterType<EfProfileQuestionDal>().As<IProfileQuestionDal>().SingleInstance();
        }

        private static void LikeTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<LikedManager>().As<ILikedService>().SingleInstance();
            builder.RegisterType<EfLikedDal>().As<ILikedDal>().SingleInstance();
        }

        private static void LikeKindTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<LikeKindManager>().As<ILikeKindService>().SingleInstance();
            builder.RegisterType<EfLikeKindDal>().As<ILikeKindDal>().SingleInstance();
        }

        private static void MatchTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<MatchManager>().As<IMatchService>().SingleInstance();
            builder.RegisterType<EfMatchDal>().As<IMatchDal>().SingleInstance();
        }

        private static void PhotoTableManager(ContainerBuilder builder)
        {
            builder.RegisterType<PhotoManager>().As<IPhotoService>().SingleInstance();
            builder.RegisterType<EfPhotoDal>().As<IPhotoDal>().SingleInstance();
        }

        private static void RoomTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
            builder.RegisterType<EfRoomDal>().As<IRoomDal>().SingleInstance();
        }

        private static void RankTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<RankManager>().As<IRankService>().SingleInstance();
            builder.RegisterType<EfRankDal>().As<IRankDal>().SingleInstance();
        }

        private static void NotificationTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<NotificationManager>().As<INotificationService>().SingleInstance();
            builder.RegisterType<EfNotificationDal>().As<INotificationDal>().SingleInstance();
        }

        private static void PreferTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<PreferManager>().As<IPreferService>().SingleInstance();
            builder.RegisterType<EfPreferDal>().As<IPreferDal>().SingleInstance();
        }

        private static void QuestionTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>().SingleInstance();
        }

        private static void ConstantRoomTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<ConstantRoomManager>().As<IConstantRoomService>().SingleInstance();
            builder.RegisterType<EfConstantRoomDal>().As<IConstantRoomDal>().SingleInstance();
        }

        private static void ChoiceTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<ChoiceManager>().As<IChoiceService>().SingleInstance();
            builder.RegisterType<EfChoiceDal>().As<IChoiceDal>().SingleInstance();
        }

        private static void ChatLevelTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<ChatLevelManager>().As<IChatLevelService>().SingleInstance();
            builder.RegisterType<EfChatLevelDal>().As<IChatLevelDal>().SingleInstance();
        }

        private static void BankTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<BankManager>().As<IBankService>().SingleInstance();
            builder.RegisterType<EfBankDal>().As<IBankDal>().SingleInstance();
        }

        private static void ProfileTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<ProfileManager>().As<IProfileService>().SingleInstance();
            builder.RegisterType<EfProfileDal>().As<IProfileDal>().SingleInstance();
        }

        private static void UserTableRegister(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
        }
    }
    
}
