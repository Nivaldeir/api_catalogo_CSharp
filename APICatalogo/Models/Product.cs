using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;
[Table("Products")]
public class Product
{
	[Key]
	public int ProductId { get; set; }

	[Required]
	[StringLength(80)]
	public string? Nome { get; set; }

	[Required]
	[StringLength(300)]
	public string? Descricao { get; set; }

	[Column(TypeName = "decimal(10,2)")]
	public decimal Preco { get; set; }

	[Required]
	[StringLength(300)]
	public string? ImageUrl { get; set; }
	public float Estoque { get; set; }
	public DateTime Datacadastro { get; set; }
	public int CategorieId { get; set; }
	[JsonIgnore]
	public Categorie? Categorie { get; set; }
}
