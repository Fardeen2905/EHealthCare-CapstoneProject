using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace CoreWebApiAngularCapstoneProject.DAL
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddUserAsync(User user)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@name", user.name));
            parameter.Add(new SqlParameter("@username", user.username));
            parameter.Add(new SqlParameter("@email", user.email));
            parameter.Add(new SqlParameter("@phone", user.phone));
            parameter.Add(new SqlParameter("@role", user.role));
            parameter.Add(new SqlParameter("@password", user.password));



            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddUser @name,@username,@email,@phone,@role,@password", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteUserAsync(int Id)
        {
            var param = new SqlParameter("@UserId", Id);
            var details = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteUser @UserId", param));
            return details;
        }

        public async Task<IEnumerable<User>> GetUserByIdAsync(int Id)
        {
            var param = new SqlParameter("@UserId", Id);
            var userDetails = await Task.Run(() => _context.Users
            .FromSqlRaw(@"exec GetUserById @UserId", param).ToListAsync());
            return userDetails;
        }
        public async Task<IEnumerable<User>> Login(string username, string password)
        {
            var param = new SqlParameter("@Userusername", username);
            var param1 = new SqlParameter("@Userpassword", password);

            var loginDetails = await Task.Run(() => _context.Users
            .FromSqlRaw(@"exec Login @Userusername, @Userpassword", param, param1).ToListAsync());
            return loginDetails;
        }
        public async Task<List<User>> GetUsersListAsync()
        {
            return await _context.Users
                 .FromSqlRaw<User>("GetUsersList")
                 .ToListAsync();
        }
    









    }
}
