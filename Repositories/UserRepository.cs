﻿using CarPooling.Data;
using CarPooling.Data.Models;
using CarPooling.RequestDTOs;

namespace CarPooling.Repositories
{
    public class UserRepository
    {
        private readonly CarPoolingDbContext dbContext;

        public UserRepository(CarPoolingDbContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
                var isEmailAlreadyExists = dbContext.Users.Any(x => x.Email == user.Email);
                if (!isEmailAlreadyExists)
                {
                    await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync();
                    return user;
                }

            throw new Exception();
        }

        public async Task<List<User>> GetUsers()
        {
           List<User> usersList = dbContext.Users.ToList();
            return usersList;
        }

        public async Task<User> GetUser(UserRequest addUserRequest )
        {
            User? existingUser = dbContext.Users.FirstOrDefault(x => x.Email == addUserRequest.Email);
            return existingUser;
        }

    }
}
