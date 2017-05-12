using NancyByExample.API.Model;

namespace NancyByExample.API.Repository
{
    public interface IUserRepository
    {
        void AddUser(int userId, User user);
        int Count();
        User GetUser(int userId);
        void RemoveUser(int userId);
    }
}