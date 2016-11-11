using System.Linq;
using System.Web.Http;
using GigHub.DataTransferObjects;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using Attendance = GigHub.DataTransferObjects.Attendance;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext context;

        public AttendancesController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(Attendance dto)
        {
            var userId = User.Identity.GetUserId();

            if (context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("The attendance already exists.");

            var attendance = new Models.Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            context.Attendances.Add(attendance);
            context.SaveChanges();

            return Ok();
        }
    }
}
