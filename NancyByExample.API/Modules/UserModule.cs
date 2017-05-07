using NancyByExample.API.Repository;
using NancyByExample.API.Domain;
using Nancy.ModelBinding;
using Nancy;
using System;

namespace NancyByExample.API.Modules
{
    public class UserModule : NancyModule
    {
        private IUserRepository _userRepository;

        public UserModule(IUserRepository userRepository) : base("user")
        {
            _userRepository = userRepository;

            Put["/{userId}"] = AddUser;
            Get["/{userId}"] = GetUser;
            Delete["/{userId}"] = DeleteUser;
            Get["/count"] = CountUsers;
        }

        public Response AddUser(dynamic parameters)
        {
            var userId = (int) parameters.UserId;
            var user = this.Bind<User>();
            _userRepository.AddUser(userId, user);
            return HttpStatusCode.OK;
        }

        public Response GetUser(dynamic parameters)
        {
            var userId = (int) parameters.UserId;
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return HttpStatusCode.NotFound;
            }
            return Response.AsJson(user);
        }

        public Response DeleteUser(dynamic parameters)
        {
            var userId = (int) parameters.UserId;
            _userRepository.RemoveUser(userId);
            return HttpStatusCode.OK;
        }

        public Response CountUsers(dynamic parameters)
        {
            var count = _userRepository.Count();
            return Response.AsJson(new {
                Count = count
            });
        }
    }
}
