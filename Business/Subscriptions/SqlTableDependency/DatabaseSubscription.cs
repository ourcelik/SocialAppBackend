using Business.Abstract;
using Core.Entities;
using Core.Subcriptions.SqlTableDependency;
using Entities.Concrete;
using Entities.DTOs.OutputDtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient.Base.EventArgs;

namespace Business.Subscriptions.SqlTableDependency
{
    public class DatabaseSubscription<T> : BaseDatabaseSubscription<T> where T: class,IEntity,new()
    {
        IUserNotificationService _userNotificationService;

        readonly private IPostCommentService _postCommentService;

        readonly private IPostService _postService;

        public DatabaseSubscription(IConfiguration configuration,
            IUserNotificationService userNotificationService,
            IPostCommentService postCommentService, 
            IPostService postService) : base(configuration.GetConnectionString("FirstDb"))
        {
            _userNotificationService = userNotificationService;
            _postCommentService = postCommentService;
            _postService = postService;
        }

        protected async override void OnChange(object sender, RecordChangedEventArgs<T> e)
        {
            if (e.Entity is UserNotificationStatistic userNotification)
            {
                await _userNotificationService.NotifyNumberOfNotificationToUserAsync(userNotification);

            }
            else if (e.Entity is CommentNotification commentNotification)
            {

                int notifyUserId = _postService.GetPostOwnerByPostId(commentNotification.PostId).Data;

                var commentContent = (await _postCommentService.GetCommentById(commentNotification.CommentId)).Data;


                await _userNotificationService.NotifyContentOfCommentToUserAsync(notifyUserId,new CommentContentNotifyDto()
                {
                    Comment = commentContent.Comment,
                    RelatedPostId = commentContent.RelatedPostId
                });
            }
        }

        protected override void OnError(object sender, ErrorEventArgs e)
        {
            base.OnError(sender, e);
        }
    }
}
