using AutoMapper;
using Shop.Domain.Entities;
using Shop.Application.Features.User.Command;
using Shop.Application.Features.User.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Add as many of these lines as you need to map your objectds
            CreateMap<AuthCommand, Shop.Domain.Entities.User>().ReverseMap();
        }

    }
}
