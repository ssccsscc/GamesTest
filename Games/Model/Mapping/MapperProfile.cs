using AutoMapper;
using DataAccess.Entities;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Model
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GenereDTO, GenereModel>().ReverseMap();
            CreateMap<GenereDTO_Create, GenereModel>().ReverseMap();
            CreateMap<CompanyDTO, CompanyModel>().ReverseMap();
            CreateMap<CompanyDTO_Create, GenereModel>().ReverseMap();
            CreateMap<GameDTO, GameModel>().ReverseMap();
            CreateMap<GameDTO_Create, GameModel>().ReverseMap();
            CreateMap<GameDTO_Update, GameModel>().ReverseMap();
        }
    }
}