using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AddressBookAPI.Entities.DataSets
{
    public class User
    {
        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User name cannot be empty")]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "User name should be in the length of 5 to 25")]
        public string UserName { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "first name should be in the length of 5 to 25")]
        public string FirstName { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "last name should be in the length of 5 to 25")]
        public string LastName { get; set; }

        [Required]
        [NotNull]
        [PasswordPropertyText]
        public string Hash { get; set; }
    }
}
