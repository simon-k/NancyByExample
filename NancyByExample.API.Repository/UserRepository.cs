using System.Collections.Generic;
using System.Linq;
using NancyByExample.API.Model;

namespace NancyByExample.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private Dictionary<int, User> _users;

        public UserRepository()
        {
            _users = new Dictionary<int, User>();
        }

        public User GetUser(int userId)
        {
            if (!_users.ContainsKey(userId)) {
                return null;
            };
            return _users[userId];
        }

        public void AddUser(int userId, User user)
        {
            if (_users.ContainsKey(userId))
            {
                _users.Remove(userId);
            };
            _users.Add(userId, user);
        }

        public void RemoveUser(int userId)
        {
            _users.Remove(userId);
        }

        public int Count()
        {
            return _users.Count();
        }

        public bool HasUser(int userId)
        {
            return _users.ContainsKey(userId);
        }
    }
}
