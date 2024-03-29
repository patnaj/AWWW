using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Test.Models;


public class CatalogModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    public virtual IList<ProductModel> Products { get; set; }
}
