using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;

namespace AddressBookAPI.Entities.DataSets
{
    public class RefTerm
    {
        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "Enter key with length from 5 to 25")]
        public string Key { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Enter descrioption with length from 5 to 50")]
        public string Description { get; set; }
    }
}
