﻿using FluentAssertions;
using Nancy;
using Nancy.Testing;
using NancyByExample.API.Model;
using NancyByExample.API.Modules;
using NancyByExample.API.Repository;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;

namespace NancyByExample.API.Tests.Modules
{
    public class UserModuleTest
    {
        private readonly IUserRepository _repository;
        private readonly Browser _browser;
        private readonly Fixture _fixture;

        public UserModuleTest()
        {
            _fixture = new Fixture();
            _repository = Substitute.For<IUserRepository>();

            _browser = new Browser(cfg =>
            {
                cfg.Module<UserModule>();
                cfg.Dependency(_repository);
            });
        }

        //TODO: Test Invalid input
        [Fact]
        public void AddUser_User_AddUserToRepositoryAndReturnOK()
        {
            var expectedUserId = _fixture.Create<int>();
            var expectedUser = _fixture.Create<User>();

            var response = _browser.Put($"/user/{expectedUserId}", with => with.JsonBody(expectedUser));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _repository.Received(1).AddUser(Arg.Is(expectedUserId), Arg.Is(expectedUser));
        }

        [Fact]
        public void GetUser_KnownUserId_ReturnUserAndOK()
        {
            var expectedUserId = _fixture.Create<int>();
            var expectedUser = _fixture.Create<User>();
            _repository.HasUser(Arg.Is<int>(userId => userId == expectedUserId)).Returns(true);
            _repository.GetUser(Arg.Is<int>(userId => userId == expectedUserId)).Returns(expectedUser);

            var response = _browser.Get($"/user/{expectedUserId}");
            var actualUser = response.Body.DeserializeJson<User>();

            actualUser.Should().Be(expectedUser);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void GetUser_UnknownUserId_ReturnNotFound()
        {
            var expectedUserId = _fixture.Create<int>();
            _repository.HasUser(Arg.Is<int>(userId => userId == expectedUserId)).Returns(false);

            var response = _browser.Delete($"/user/{expectedUserId}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void DeleteUser_KnownUserId_DeletesUserFromRepositoryAndReturnOK()
        {
            var expectedUserId = _fixture.Create<int>();
            _repository.HasUser(Arg.Is<int>(userId => userId == expectedUserId)).Returns(true);

            var response = _browser.Delete($"/user/{expectedUserId}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _repository.Received(1).RemoveUser(Arg.Is(expectedUserId));
        }

        [Fact]
        public void DeleteUser_UnknownUserId_ReturnNotFound()
        {
            var expectedUserId = _fixture.Create<int>();
            _repository.HasUser(Arg.Is<int>(userId => userId == expectedUserId)).Returns(false);

            var response = _browser.Delete($"/user/{expectedUserId}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public void CountUsers_ReturnsNumberOfUsersAndOK()
        {
            var expectedUserCount = _fixture.Create<int>();
            _repository.Count().Returns(expectedUserCount);

            var response = _browser.Get("/user/count");
            var actualUserCount = (int)response.Body.DeserializeJson<dynamic>()["Count"];

            actualUserCount.Should().Be(expectedUserCount);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
