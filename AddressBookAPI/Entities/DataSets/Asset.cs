using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;

namespace AddressBookAPI.Entities.DataSets
{
    public class Asset
    {
        private byte[] content;

        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 1, ErrorMessage = "Enter a valid filename")]
        public string FileName { get; set; }

        [Required]
        [NotNull]
        [Url]
        public string DownloadUrl { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetMappingId")]
        public Guid FileTypeId { get; set; }

        [Required]
        [NotNull]
        public int size { get; set; }

        [Required]
        [NotNull]
        public byte[] Content { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("AddressBookId")]
        public Guid AddressBookId { get; set; }
        public AddressBook AddressBook { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
