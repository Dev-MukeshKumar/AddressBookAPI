using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name:"address_book")]
    public class AddressBook
    {
        [Required, NotNull, Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Required, NotNull, StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "first name should be in the length of 5 to 25")]
        [Column(name: "first_name")]
        public string FirstName { get; set; }

        [Required, NotNull, StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "last name should be in the length of 5 to 25")]
        [Column(name: "last_name")]
        public string LastName { get; set; }

        [Required, NotNull, ForeignKey("UserId")]
        [Column(name: "user_id")]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
