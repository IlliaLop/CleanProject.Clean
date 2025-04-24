using CleanProject.BlazorUI.Services.Base;

namespace CleanProject.BlazorUI.Contracts
{
    public interface ILeaveAllocationService
    {
        Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId);
    }
}
