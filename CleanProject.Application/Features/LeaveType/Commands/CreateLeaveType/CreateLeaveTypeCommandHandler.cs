﻿using AutoMapper;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Exceptions;
using CleanProject.Domain;
using MediatR;

namespace CleanProject.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave type", validationResult);

            // convert to domain entity object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            // add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            // retun record id
            return leaveTypeToCreate.Id;
        }
    }
}
