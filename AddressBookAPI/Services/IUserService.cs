using AddressBookAPI.Entities.Models;
using AddressBookAPI.Helpers.Responses;
using System;

namespace AddressBookAPI.Services
{
    public interface IUserService
    {
        TokenResponse AuthUser(UserDTO userData);
        UserResponse CreateUser(UserCreationDTO user);
        UserResponse DeleteUser(Guid userId, Guid tokenUserId);
        UserResponse GetUserById(Guid userId, Guid tokenUserId);
        UserResponse GetUserByUserName(string userName);
        UserResponse UpdateUser(Guid userId, Guid tokenUserId, UserUpdationDTO userData);
    }
}