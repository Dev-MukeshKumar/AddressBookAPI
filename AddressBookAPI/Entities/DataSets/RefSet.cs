using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookAPI.Entities.DataSets
{
    [Table(name: "ref_set")]
    public class RefSet
    {
        [Required]
        [NotNull]
        [Key]
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "Enter set name with length from 5 to 25")]
        [Column(name: "set")]
        public string Set { get; set; }

        [Required]
        [NotNull]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Enter descrioption with length from 5 to 50")]
        [Column(name: "description")]
        public string Description { get; set; }

    }
}
