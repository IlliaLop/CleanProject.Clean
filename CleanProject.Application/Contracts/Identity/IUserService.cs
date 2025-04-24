using CleanProject.Application.Models.Identity;

namespace CleanProject.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
        public string UserId { get; }
    }
}
