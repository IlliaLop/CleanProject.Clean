using AutoMapper;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Exceptions;
using CleanProject.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace CleanProject.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // verify that record exists
        if (leaveType == null)
            throw new NotFoundException(nameof(LeaveType), request.Id);

        // convert data object to DTO object
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

        // return DTO object
        return data;
    }
}
