using CleanProject.BlazorUI.Contracts;
using CleanProject.BlazorUI.Models.LeaveRequests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace CleanProject.BlazorUI.Pages.LeaveRequests
{
    public partial class Index
    {
        [Inject] ILeaveRequestService leaveRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public AdminLeaveRequestViewVM Model { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Model = await leaveRequestService.GetAdminLeaveRequestList();
        }

        void GoToDetails(int id)
        {
            NavigationManager.NavigateTo($"/leaverequests/details/{id}");
        }
    }
}