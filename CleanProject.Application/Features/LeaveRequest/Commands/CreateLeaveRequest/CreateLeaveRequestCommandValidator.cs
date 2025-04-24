using FluentValidation;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Features.LeaveRequest.Shared;
using CleanProject.Application.Features.LeaveRequests.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanProject.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));
        }
    }
}
