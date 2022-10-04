using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name: "set_term_mapping")]
    public class RefSetMapping
    {

        [Required]
        [NotNull]
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefSetId")]
        [Column(name: "ref_set_id")]
        public Guid RefSetId { get; set; }
        public RefSet RefSet { get; set; }

        [Required]
        [NotNull]
        [ForeignKey("RefTermId")]
        [Column(name: "ref_term_id")]
        public Guid RefTermId { get; set; }
        public RefTerm RefTerm { get; set; }

    }
}
