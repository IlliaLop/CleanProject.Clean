using CleanProject.Application.DTOs;
using CleanProject.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanProject.Application.Features.LeaveRequests.Requests.Queries;

public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDetailsDto>
{
    public int Id { get; set; }
}
