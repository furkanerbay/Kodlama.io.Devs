﻿using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Technology mappedTechnology = _mapper.Map<Domain.Entities.Technology>(request);
                Domain.Entities.Technology deleteTechnology = await _technologyRepository.DeleteAsync(mappedTechnology);
                DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deleteTechnology);
                return deletedTechnologyDto;
            }
        }
    }
}
