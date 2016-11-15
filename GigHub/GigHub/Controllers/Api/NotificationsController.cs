using AutoMapper;
using GigHub.DataTransferObjects;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {

        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDTO> GetNewNotifications()
        {
            string userId = User.Identity.GetUserId();

            var notifications = context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();


            return notifications.Select(Mapper.Map<Notification, NotificationDTO>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();

            notifications.ForEach(n => n.Read());

            context.SaveChanges();

            return Ok();
        }
    }
}
