﻿using Application.Features.ProgramingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguages
{
    public class GetListProgramingLanguageQuery : IRequest<ProgramingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Domain.Entities.ProgramingLanguage> programingLanguages = await _programingLanguageRepository.GetListAsync(
                        index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize
                    );

                ProgramingLanguageListModel programingLanguageListModel = _mapper.Map<ProgramingLanguageListModel>(programingLanguages);

                return programingLanguageListModel;
            }
        }
    }
}
