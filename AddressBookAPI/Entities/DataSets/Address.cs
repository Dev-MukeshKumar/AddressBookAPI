using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name:"address")]
    public class Address
    {
        [Required, NotNull, Key]
        [Column(name:"id")]
        public Guid Id { get; set; }

        [Required, NotNull, StringLength(maximumLength: 25, MinimumLength = 5)]
        [Column(name: "line_1")]
        public string Line1 { get; set; }

        [Required, NotNull, StringLength(maximumLength: 25, MinimumLength = 5)]
        [Column(name: "line_2")]
        public string Line2 { get; set; }

        [Required, NotNull, StringLength(maximumLength: 25, MinimumLength = 5)]
        [Column(name: "city")]
        public string City { get; set; }

        [Required, NotNull, StringLength(maximumLength: 25, MinimumLength = 5)]
        [Column(name: "state_name")]
        public string StateName { get; set; }

        [Required, NotNull, RegularExpression(@"^(\w{6})$", ErrorMessage = "The PostalCode must be 6 digits long.")]
        [Column(name:"zip_code")]
        public string ZipCode { get; set; }

        [Required, NotNull, ForeignKey("RefSetMappingId")]
        [Column(name: "address_type_id")]
        public Guid AddressTypeId { get; set; }

        [Required, NotNull, ForeignKey("RefSetMappingId")]
        [Column(name: "country_type_id")]
        public Guid CountryTypeId { get; set; }

        [Required, NotNull, ForeignKey("AddressBookId")]
        [Column(name: "address_book_id")]
        public Guid AddressBookId { get; set; }
        public AddressBook AddressBook { get; set; }

        [Required, NotNull, ForeignKey("UserId")]
        [Column(name: "user_id")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
