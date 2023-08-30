using Application.Features.ProgramingLanguage.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.ProgramingLanguage.Commands.CreateProgramingLanguages
{
    public class CreateProgramingLanguageCommand : IRequest<CreatedProgramingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, CreatedProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public CreateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                Domain.Entities.ProgramingLanguage mappedProgramingLanguage = _mapper.Map<Domain.Entities.ProgramingLanguage>(request);
                Domain.Entities.ProgramingLanguage createdProgramingLanguage = await _programingLanguageRepository.AddAsync(mappedProgramingLanguage);
                CreatedProgramingLanguageDto createdProgramingLanguageDto = _mapper.Map<CreatedProgramingLanguageDto>(createdProgramingLanguage);

                return createdProgramingLanguageDto;
            }
        }

    }
}
