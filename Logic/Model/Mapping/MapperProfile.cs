using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Genere, GenereModel>().ReverseMap();
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<Game, GameModel>().ReverseMap();
        }
    }
}