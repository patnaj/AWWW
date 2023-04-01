using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_test.Models
{
    public class PersonModelView
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[A-Z][a-z]*$")]
        public string Name { get; set; }
    }

    public class PersonModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}