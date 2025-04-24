using MediatR;

namespace CleanProject.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationListQuery : IRequest<List<LeaveAllocationDto>>
{
}
