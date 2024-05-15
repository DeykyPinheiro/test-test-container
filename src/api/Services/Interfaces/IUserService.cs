using api.Models;

namespace api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int userId);
        Task Save(User user);
        Task Update(int userId, User model);
        Task Delete(int userId);
    }
}
