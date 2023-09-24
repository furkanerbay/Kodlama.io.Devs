using Application.Features.ProgramingLanguage.Commands.CreateProgramingLanguages;
using Application.Features.ProgramingLanguage.Dtos;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Domain.Entities.Technology, TechnologyListDto>()
                .ForMember(t => t.ProgramingLanguageName, opt => opt.MapFrom(c => c.ProgramingLanguage.Name))
                .ReverseMap();

            CreateMap<Domain.Entities.Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<Domain.Entities.Technology, UpdateTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, UpdateTechnologyCommand>().ReverseMap();
            
        }
    }
}
