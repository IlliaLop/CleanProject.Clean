using AutoMapper;
using CleanProject.Application.DTOs.LeaveRequest;
using CleanProject.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using CleanProject.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using CleanProject.Application.Features.LeaveRequests.Requests.Commands;
using CleanProject.Domain;

namespace CleanProject.Application.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
        }
    }
}
