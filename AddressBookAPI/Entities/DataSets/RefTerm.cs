using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AddressBookAPI.Entities.DataSets
{
    [Table("ref_term")]
    public class RefTerm
    {
        [Required,NotNull,Key]
        [Column(name:"id")]
        public Guid Id { get; set; }

        [Required,NotNull,StringLength(maximumLength: 25, MinimumLength = 5, ErrorMessage = "Enter key with length from 5 to 25")]
        [Column(name: "key")]
        public string Key { get; set; }

        [Required, NotNull, StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Enter descrioption with length from 5 to 50")]
        [Column(name: "description")]
        public string Description { get; set; }

    }
}
