﻿using AutoMapper;
using BuildingVitals.BusinessContracts.Models;
using BuildingVitals.BusinessContracts.Models.Identity;
using BuildingVitals.DataAccessContracts.Entities.Identity;

namespace BuildingVitals.BusinessImplementations.Configurations.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserIdentityModel>();
            CreateMap<UserIdentityModel, User>();
            CreateMap<AddUserModel, User>();

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<AddUserModel, User>();
            CreateMap<EditUserModel, User>();
        }
    }
}
