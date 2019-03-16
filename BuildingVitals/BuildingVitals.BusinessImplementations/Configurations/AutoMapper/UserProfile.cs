using AutoMapper;
using BuildingVitals.BusinessContracts.Models.Identity;
using BuildingVitals.DataAccessContracts.Entities.Identity;

namespace BuildingVitals.BusinessImplementations.Configurations.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
