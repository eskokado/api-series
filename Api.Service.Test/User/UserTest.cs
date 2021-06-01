using System;
using System.Collections.Generic;
using Api.Domain.Dtos;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameUpdate { get; set; }
        public static string UserEmailUpdate { get; set; }
        public Guid UserId { get; set; }

        public List<UserDtoResult> listUserDto = new List<UserDtoResult>();

        public UserDtoResult userDtoResult = new UserDtoResult();
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;

        public UserTest()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameUpdate = Faker.Name.FullName();
            UserEmailUpdate = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var result = new UserDtoResult()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listUserDto.Add(result);
            }

            userDtoResult = new UserDtoResult() 
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            userDtoCreate = new UserDtoCreate()
            {
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreateResult = new UserDtoCreateResult()
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate()
            {
                Id = UserId,
                Name = UserNameUpdate,
                Email = UserEmailUpdate
            };

            userDtoUpdateResult = new UserDtoUpdateResult()
            {
                Id = UserId,
                Name = UserNameUpdate,
                Email = UserEmailUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}