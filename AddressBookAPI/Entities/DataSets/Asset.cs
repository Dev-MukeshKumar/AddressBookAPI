using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name:"asset")]
    public class Asset
    {

        [Required]
        [NotNull]
        [Key]
        [Column(name:"id")]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 1, ErrorMessage = "Enter a valid filename")]
        [Column(name: "file_name")]
        public string FileName { get; set; }

        [Required]
        [NotNull]
        [Url]
        [Column(name: "download_url")]
        public string DownloadUrl { get; set; }

        [Required]
        [NotNull]
        [Column(name: "file_type")]
        public string FileType { get; set; }

        [Required]
        [NotNull]
        [Column(name: "size")]
        public decimal Size { get; set; }

        [Required]
        [NotNull]
        [Column(name: "content")]
        public string Content { get; set; }

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
