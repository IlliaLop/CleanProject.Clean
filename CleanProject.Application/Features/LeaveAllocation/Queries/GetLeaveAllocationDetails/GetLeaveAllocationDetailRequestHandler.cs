using AutoMapper;
using CleanProject.Application.DTOs;
using CleanProject.Application.DTOs.LeaveAllocation;
using CleanProject.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanProject.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using CleanProject.Application.Exceptions;

namespace CleanProject.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDetailsDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            if (leaveAllocation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
        }
    }
}
