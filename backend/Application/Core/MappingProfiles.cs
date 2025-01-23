using Application.Activities.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, ActivityDto>().ReverseMap();
    }
}
