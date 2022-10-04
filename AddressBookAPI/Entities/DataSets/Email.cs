using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name: "email")]
    public class Email
    {
        [Required]
        [NotNull]
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [EmailAddress]
        [Column(name: "email_address")]
        public string EmailAddress { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetMappingId")]
        [Column(name: "email_type_id")]
        public Guid EmailTypeId { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("AddressBookId")]
        [Column(name: "address_book_id")]
        public Guid AddressBookId { get; set; }
        public AddressBook AddressBook { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("UserId")]
        [Column(name: "user_id")]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
