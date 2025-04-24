using AutoMapper;
using CleanProject.Application.Features.LeaveType.Commands.CreateLeaveType;
using CleanProject.Application.Features.LeaveType.Commands.UpdateLeaveType;
using CleanProject.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanProject.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using CleanProject.Domain;

namespace CleanProject.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
