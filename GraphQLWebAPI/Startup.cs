using DataAccess.Concrete.EntityFramework;
using GraphQL.Server.Ui.Voyager;
using GraphQLWebAPI.GraphQL;
using GraphQLWebAPI.GraphQL.Tables.Banks;
using GraphQLWebAPI.GraphQL.Tables.ChatLevels;
using GraphQLWebAPI.GraphQL.Tables.Choices;
using GraphQLWebAPI.GraphQL.Tables.ConstantRoomMembers;
using GraphQLWebAPI.GraphQL.Tables.ConstantRooms;
using GraphQLWebAPI.GraphQL.Tables.Genders;
using GraphQLWebAPI.GraphQL.Tables.LikeKinds;
using GraphQLWebAPI.GraphQL.Tables.Likes;
using GraphQLWebAPI.GraphQL.Tables.Matches;
using GraphQLWebAPI.GraphQL.Tables.Notifications;
using GraphQLWebAPI.GraphQL.Tables.Prefers;
using GraphQLWebAPI.GraphQL.Tables.ProfileQuestions;
using GraphQLWebAPI.GraphQL.Tables.Questions;
using GraphQLWebAPI.GraphQL.Tables.Ranks;
using GraphQLWebAPI.GraphQL.Tables.RoomMembers;
using GraphQLWebAPI.GraphQL.Tables.Rooms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLWebAPI
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
            services.AddPooledDbContextFactory<SocialAppGraphQLContext>(opt => opt.UseSqlServer(
             Configuration.GetConnectionString("GraphQLStr")));
            services.AddGraphQLServer()
               .AddQueryType<Query>()
               .AddMutationType<Mutation>()
               .AddSubscriptionType<Subscription>()
               .AddType<QuestionType>()
               .AddType<ChoiceType>()
               .AddType<ChatLevelType>()
               .AddType<ConstantRoomType>()
               .AddType<BankType>()
               .AddType<ConstantRoomMemberType>()
               .AddType<GenderType>()
               .AddType<LikeKindType>()
               .AddType<LikeType>()
               .AddType<MatchType>()
               .AddType<NotificationType>()
               .AddType<PreferType>()
               .AddType<ProfileType>()
               .AddType<ProfileQuestionType>()
               .AddType<RankType>()
               .AddType<RoomMemberType>()
               .AddType<RoomType>()
               .AddFiltering()
               .AddSorting()
               .AddInMemorySubscriptions()
               .AddDefaultTransactionScopeHandler();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseWebSockets();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
            }, "/map");
        }
    }
}
