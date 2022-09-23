using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;

namespace AddressBookAPI.Entities.DataSets
{
    public class Phone
    {
        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength:13,MinimumLength =4,ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("AddressBookId")]
        public Guid AddressBookId { get; set; }
        public AddressBook AddressBook { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetMappingId")]
        public Guid PhoneTypeId { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
