// ef adnotation
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Lab3.Models
{
    public class TagModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        // klucze obce
        public virtual IList<ProductModel> Products { get; set; }
    }
}