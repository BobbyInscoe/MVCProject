using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // API -> Outbound
            Mapper.CreateMap<Customer, CustomerDto>();
            //API <- Inbound
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); // Opt used to ignore customer Id for Inbound requests because Id never changes.

            // API -> Outbound
            Mapper.CreateMap<Movie, MovieDto>();
            //API <- Inbound
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());


            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            Mapper.CreateMap<GenreType, GenreTypeDto>();
        }
    }
}