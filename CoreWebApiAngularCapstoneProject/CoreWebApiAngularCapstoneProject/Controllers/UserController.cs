using CoreWebApiAngularCapstoneProject.DAL;
using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiAngularCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("getuserlist")]

        public async Task<List<User>> GetUsersListAsync()
        {
            try
            {
                return await userService.GetUsersListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("getaccountID")]

        public async Task<IEnumerable<User>> GetUserByIdAsync(int Id)
        {
            try
            {
                var response = await userService.GetUserByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Login")]
        public async Task<IEnumerable<User>> Login(string username, string password)
        {
            try
            {
                var response = await userService.Login(username, password);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }


        [HttpPost("adduser")]

        public async Task<IActionResult> AddUserAsync(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await userService.AddUserAsync(user);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        

     
        [HttpDelete("deleteuserbyid")]

        public async Task<int> DeleteUserById(int Id)
        {
           
            try
            {
                var response = await userService.DeleteUserAsync(Id);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
