using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    public class FollowingDto
    {
        public string FolloweeId { get; set; }
    }

    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext context;

        public FollowingsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists.");

            var following = new Following
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
