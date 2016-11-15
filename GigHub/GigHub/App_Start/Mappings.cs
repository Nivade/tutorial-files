using AutoMapper;
using GigHub.DataTransferObjects;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class Mappings
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<Gig, GigDTO>();
                cfg.CreateMap<Notification, NotificationDTO>();
            });
        }
    }
}