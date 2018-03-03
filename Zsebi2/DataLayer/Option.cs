using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zsebi2.DataLayer
{
    [Table("Options")]
    public class Option
    {
        [Key]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(Int32.MaxValue)]
        public string Value { get; set; }
    }
}