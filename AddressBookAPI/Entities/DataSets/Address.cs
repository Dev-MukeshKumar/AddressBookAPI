using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    public class Address
    {
        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string Line1 { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string Line2 { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string City { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string StateName { get; set; }

        [Required]
        [NotNull]
        [RegularExpression(@"^(\d{6})$", ErrorMessage = "The PostalCode must be 6 digits long.")]
        public int ZipCode { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("AddressBookId")]
        public Guid AddressBookId { get; set; }
        public AddressBook AddressBook { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetMappingId")]
        public Guid AddressTypeId { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
