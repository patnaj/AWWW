using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMVC.Models
{
    public class Mark
    {
        [Key]
        public int Id {get;set;}
        public string StudentId {get;set;} = "";
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Subject { get; set; } = "";
    }
}