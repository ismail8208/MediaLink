﻿using AutoMapper;
using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Jobs.Queries;
public class JobDto : IMapFrom<Job>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    public List<Skill>? Skills { get; set; }
    public string? UserName { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Job, JobDto>()
            .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName));
    }
}
