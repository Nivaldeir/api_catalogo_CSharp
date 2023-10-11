using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
[Table("Categories")]
public class Categorie
{
    public Categorie()
    {
        Products = new Collection<Product>();
    }
    [Key]
    public int CategorieId{ get; set; }
    [Required]
    [MaxLength(80)]
    public string? Nome { get; set; }
    [Required]
    [MaxLength(300)]
    public string? ImageUrl { get; set; }
    public ICollection<Product>? Products { get; set; }
}
