using AddressBookAPI.Entities.DataSets;
using AddressBookAPI.Entities.Models;
using AddressBookAPI.Helpers.Responses;
using AddressBookAPI.Helpers.Security.Hashing;
using AddressBookAPI.Services.Repositories;
using AutoMapper;
using System;

namespace AddressBookAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public UserResponse GetUserById(Guid userId, Guid tokenUserId)
        {

            if (!userId.Equals(tokenUserId))
                return new UserResponse(false, "User not found", null);

            var user = _userRepository.GetUser(userId);

            if (user == null)
                return new UserResponse(false, "User not found", null);

            return new UserResponse(true, null, user);
        }

        public UserResponse GetUserByUserName(string userName)
        {
            var user = _userRepository.GetUser(userName);

            if (user == null)
                return new UserResponse(false, "User not found", null);

            return new UserResponse(true, null, user);
        }

        public TokenResponse AuthUser(UserDTO userData)
        {
            var user = _userRepository.GetUser(userData.UserName);

            if (user == null)
                return new TokenResponse(false, "User not authenticated", null, null);

            if (_passwordHasher.PasswordMatches(userData.Password, user.Hash))
                return new TokenResponse(true, "", _jwtService.GenerateSecurityToken(user), "bearer");
            
            return new TokenResponse(false, "User not authenticated", null, null);
        }

        public UserResponse CreateUser(UserCreationDTO userData) { 
            
            var user = _userRepository.GetUser(userData.UserName);

            if (user != null)
                return new UserResponse(false, "Username already exists", null);

            var userToSave = new User()
            {
                UserName = userData.UserName,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Hash = _passwordHasher.HashPassword(userData.Password),
            };

            _userRepository.CreateUser(userToSave);
            _unitOfWork.Save();

            return new UserResponse(true,"",userToSave);
        }

        public UserResponse UpdateUser(Guid userId, Guid tokenUserId, UserUpdationDTO userData)
        {
            if (!userId.Equals(tokenUserId))
                return new UserResponse(false, "User not found", null);

            var user = _userRepository.GetUser(userId);

            if (user == null)
                return new UserResponse(false, "User not found", null);

            if (!string.IsNullOrEmpty(userData.UserName))
                user.UserName = userData.UserName;

            if (!string.IsNullOrEmpty(userData.FirstName))
                user.FirstName = userData.FirstName;

            if (!string.IsNullOrEmpty(userData.LastName))
                user.LastName = userData.LastName;

            if (!string.IsNullOrEmpty(userData.Password))
                user.Hash = _passwordHasher.HashPassword(userData.Password);

            _userRepository.UpdateUser(user);
            _unitOfWork.Save();

            return new UserResponse(true, "Updated user data successfully", user);
        }

        public UserResponse DeleteUser(Guid userId, Guid tokenUserId)
        {
            if (!userId.Equals(tokenUserId))
                return new UserResponse(false, "User not found", null);

            var user = _userRepository.GetUser(userId);

            if (user == null)
                return new UserResponse(false, "User not found", null);

            _userRepository.DeleteUser(user);
            _unitOfWork.Save();

            return new UserResponse(true, null, user);
        }

    }
}
