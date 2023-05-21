using CoreWebApiAngularCapstoneProject.Models;

namespace CoreWebApiAngularCapstoneProject.DAL
{
    public interface IUserService
    {
        public Task<List<User>> GetUsersListAsync();

        public Task<IEnumerable<User>> GetUserByIdAsync(int Id);

        public Task<int> AddUserAsync(User user);

        public Task<int> DeleteUserAsync(int Id);

        public Task<IEnumerable<User>> Login(string username, string password);
    }
}
