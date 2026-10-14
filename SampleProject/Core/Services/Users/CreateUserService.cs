using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class CreateUserService : ICreateUserService
    {
        private readonly IUpdateUserService _updateUserService;
        private readonly IIdObjectFactory<User> _userFactory;
        private readonly IUserRepository _userRepository;

        public CreateUserService(IIdObjectFactory<User> userFactory, IUserRepository userRepository, IUpdateUserService updateUserService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _updateUserService = updateUserService;
        }

        public User Create(Guid id, string name, string email, UserTypes type, int? age, decimal? annualSalary, IEnumerable<string> tags)
        {
            // Check whether the user already exists in the repository
            var user = _userRepository.Get(id);

            // If the user does not exist, create a new instance using the factory
            if (user == null)
            {
                user = _userFactory.Create(id);
            }

            // Update the user using the update service
            _updateUserService.Update(user, name, email, type, age, annualSalary, tags);

            // Save the user to the repository
            _userRepository.Save(user);

            return user;
        }
    }
}