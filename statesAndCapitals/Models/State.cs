using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statesAndCapitals.Models
{
    [Table("State")]
    public partial class State
    {
        [Key]
        public int StateId { get; set; }
        [Column("State")]
        [StringLength(255)]
        public string? State1 { get; set; }
        [StringLength(255)]
        public string? Capital { get; set; }
    }
}
