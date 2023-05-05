// ef adnotation
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618
namespace Lab3.Models
{
    public class CatalogModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^\U\u{,20}$")]
        public string? Title { get; set; }
        // klucze obce
        public virtual IList<ProductModel> Products { get; set; }
        public virtual IList<TagModel> Tags { get; set; }
    }

}