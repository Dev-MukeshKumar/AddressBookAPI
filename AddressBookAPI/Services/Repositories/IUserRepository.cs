using AddressBookAPI.Entities.DataSets;
using System;

namespace AddressBookAPI.Services.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(User user);
        User GetUser(Guid userId);
        User GetUser(string userName);
        void UpdateUser(User user);
    }
}