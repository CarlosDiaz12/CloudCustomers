using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services.Users
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
    }
}
