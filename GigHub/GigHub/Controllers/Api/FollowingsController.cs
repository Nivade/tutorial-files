using System.Linq;
using System.Web.Http;
using GigHub.DataTransferObjects;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using Following = GigHub.DataTransferObjects.Following;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext context;

        public FollowingsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(Following dto)
        {
            var userId = User.Identity.GetUserId();

            if (context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists.");

            var following = new Models.Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            context.Followings.Add(following);
            context.SaveChanges();

            return Ok();
        }
    }
}