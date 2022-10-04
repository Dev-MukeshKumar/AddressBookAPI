using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name: "phone")]
    public class Phone
    {
        [Required]
        [NotNull]
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength:13,MinimumLength =4,ErrorMessage = "Enter a valid phone number")]
        [Column(name: "phone_number")]
        public string PhoneNumber { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetMappingId")]
        [Column(name: "phone_type_id")]
        public Guid PhoneTypeId { get; set; }

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
