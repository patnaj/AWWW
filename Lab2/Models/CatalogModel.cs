// ef adnotation
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Lab2.Models
{
    public class CatalogModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        // klucze obce
        public virtual IList<ProductModel> Products { get; set; }
        public virtual IList<TagsModel> Tags { get; set; }
    }

    public class TagsModel
    {   
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual IList<CatalogModel> Catalogs { get; set; }
    }
}