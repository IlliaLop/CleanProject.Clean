using AutoMapper;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Exceptions;
using MediatR;

namespace CleanProject.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest == null)
            throw new NotFoundException(nameof(LeaveRequest), request.Id);

        await _leaveRequestRepository.DeleteAsync(leaveRequest);
        return Unit.Value;
    }
}
