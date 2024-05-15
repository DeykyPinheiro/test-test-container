using api.Models;
using api.Services.Interfaces;

namespace api.Services
{
    public class UserService : IUserService
    {
        public Task Save(User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task Update(int userId, User model)
        {
            throw new NotImplementedException();
        }
    }
}
