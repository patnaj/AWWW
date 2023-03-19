// ef adnotation
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Lab2.Models
{
    public class ProductModel
    {
        // kolumny tabeli
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int CatalogId { get; set; }

        // klucze obce
        public virtual IList<TagModel> Tags { get; set; }
        [ForeignKey("CatalogId")]
        public virtual CatalogModel Catalog { get; set; }
    }
}