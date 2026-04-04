using System;
using Application.DTOs.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.PasswordHashed, opt => opt.Ignore());
    }
}
