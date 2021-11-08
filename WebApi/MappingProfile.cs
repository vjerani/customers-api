using AutoMapper;
using Core.Entities;
using System;
using WebApi.CustomerEndpoints;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dto => dto.Version, options => options.MapFrom(src => src.RowVersion));
        }
    }
}
