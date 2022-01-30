using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace statesAndCapitals.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            TestResults = new HashSet<TestResult>();
        }

        [Key]
        public int UserId { get; set; }
        [StringLength(255)]
        public string? UserName { get; set; }
        [StringLength(255)]
        public string? Password { get; set; }

        [InverseProperty(nameof(TestResult.User))]
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
