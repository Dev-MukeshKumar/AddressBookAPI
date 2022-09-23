using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    public class Email
    {
        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("AddressBookId")]
        public Guid AddressBookId { get; set; }
        public AddressBook AddressBook { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetMappingId")]
        public Guid EmailTypeId { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
