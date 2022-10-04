namespace AddressBookAPI.Entities.Models
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserCreationDTO: UserDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserUpdationDTO: UserDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
