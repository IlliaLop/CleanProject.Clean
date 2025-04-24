using AutoMapper;
using CleanProject.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using CleanProject.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using CleanProject.Application.Features.LeaveAllocations.Requests.Commands;
using CleanProject.Domain;

namespace CleanProject.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
