﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanProject.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
