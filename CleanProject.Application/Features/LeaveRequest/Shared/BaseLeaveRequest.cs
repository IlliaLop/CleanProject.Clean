using System;
using System.Collections.Generic;
using System.Text;

namespace CleanProject.Application.DTOs.LeaveRequest
{
    public abstract class BaseLeaveRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
