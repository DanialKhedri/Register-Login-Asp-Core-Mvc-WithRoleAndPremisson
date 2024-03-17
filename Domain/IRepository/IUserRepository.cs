using Domain.Entities.Role;
using Domain.Entities.User;


namespace Domain.IRepository
{
    public interface IUserRepository
    {

        Task<bool> AddUserToDataBase(User user);

        Task<bool> LogInUser(User user);

        Task<List<Role>> IsAdmin(int UserId);

        public Task<User> GetUserById(int UserId);

        public List<User> GetListOfUser();

        public List<int> GetRoleOfUserById(int UserId);

        public Task<bool> EditUserDto(User user);


    }
}
