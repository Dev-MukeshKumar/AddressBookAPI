using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name: "user")]
    public class User
    {
        [Required]
        [NotNull]
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User name cannot be empty")]
        [NotNull]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Column(name: "user_name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name cannot be empty")]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "User name should be in the length of 5 to 25")]
        [Column(name: "first_name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty")]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "User name should be in the length of 5 to 25")]
        [Column(name: "last_name")]
        public string LastName { get; set; }

        [Required]
        [NotNull]
        [PasswordPropertyText]
        [Column(name: "hash")]
        public string Hash { get; set; }
    }
}
