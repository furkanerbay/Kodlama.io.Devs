using Application.Features.ProgramingLanguage.Commands.CreateProgramingLanguages;
using Application.Features.ProgramingLanguage.Dtos;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.ProgramingLanguage, CreatedProgramingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
            CreateMap<Domain.Entities.ProgramingLanguage, ProgramingLanguageListDto>().ReverseMap();

            CreateMap<Domain.Entities.ProgramingLanguage, ProgramingLanguageGetByIdDto>().ReverseMap();

            CreateMap<Domain.Entities.ProgramingLanguage, DeleteProgramingLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.ProgramingLanguage, DeletedProgramingLanguageDto>().ReverseMap();

            CreateMap<Domain.Entities.ProgramingLanguage, UpdateProgramingLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.ProgramingLanguage, UpdatedProgramingLanguageDto>().ReverseMap();
        }
    }
}
