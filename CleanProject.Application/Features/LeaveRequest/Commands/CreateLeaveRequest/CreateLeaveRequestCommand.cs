using CleanProject.Application.DTOs.LeaveRequest;
using CleanProject.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace CleanProject.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public string RequestComments { get; set; } = string.Empty;
    }
}
