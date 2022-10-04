using AddressBookAPI.Entities.DataSets;

namespace AddressBookAPI.Services
{
    public interface IJwtService
    {
        string GenerateSecurityToken(User user);
        int? ValidateJwtToken(string token);
    }
}