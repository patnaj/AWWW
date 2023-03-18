using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models;

public class ProductModel
{  
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Desc { get; set; }
    
    public int CatalogId { get; set; }
    
    [ForeignKey("CatalogId")]
    public virtual CatalogModel Catalog { get; set; }
}
