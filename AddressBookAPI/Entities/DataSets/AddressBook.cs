using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    public class AddressBook
    {
        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

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
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
