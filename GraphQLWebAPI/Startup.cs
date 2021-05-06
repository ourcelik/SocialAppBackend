using DataAccess.Concrete.EntityFramework;
using GraphQL.Server.Ui.Voyager;
using GraphQLWebAPI.GraphQL;
using GraphQLWebAPI.GraphQL.Banks;
using GraphQLWebAPI.GraphQL.ChatLevels;
using GraphQLWebAPI.GraphQL.Choices;
using GraphQLWebAPI.GraphQL.ConstantRoomMembers;
using GraphQLWebAPI.GraphQL.ConstantRooms;
using GraphQLWebAPI.GraphQL.Genders;
using GraphQLWebAPI.GraphQL.LikeKinds;
using GraphQLWebAPI.GraphQL.Likes;
using GraphQLWebAPI.GraphQL.Matches;
using GraphQLWebAPI.GraphQL.Notifications;
using GraphQLWebAPI.GraphQL.Prefers;
using GraphQLWebAPI.GraphQL.ProfileQuestions;
using GraphQLWebAPI.GraphQL.Questions;
using GraphQLWebAPI.GraphQL.Ranks;
using GraphQLWebAPI.GraphQL.RoomMembers;
using GraphQLWebAPI.GraphQL.Rooms;
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
               .AddInMemorySubscriptions();
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
