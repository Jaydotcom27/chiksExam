using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statesAndCapitals.Models
{
    [Table("TestResult")]
    public partial class TestResult
    {
        [Key]
        public int TestResultId { get; set; }
        public int? UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TestDateTime { get; set; }
        public int? TotalQuestions { get; set; }
        public int? NumberCorrect { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("TestResults")]
        public virtual User? User { get; set; }
    }
}
