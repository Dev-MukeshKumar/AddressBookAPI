using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    public class RefSetMapping
    {
        [Required]
        [NotNull]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetId")]
        public Guid RefSetId { get; set; }
        public RefSet RefSetRecord { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefTermId")]
        public Guid RefTermId { get; set; }
        public RefSet RefTermRecord { get; set; }

    }
}
