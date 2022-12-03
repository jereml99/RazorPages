using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel;

public enum SupportedTypes
{
    [Description("fizzy")]
    fizzy,
    [Description("nonfizzy")]
    nonfizzy
}

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
    [StringLength(50, ErrorMessage = "The Name value cannot exceed 50 characters. ")]
    public string? Name { get; set; }

	[Required]
	private SupportedTypes type;
    public SupportedTypes Type
    {
        get { return type; }
        set
        {
            if (!Enum.IsDefined(typeof(SupportedTypes), value))
                throw new ArgumentOutOfRangeException();
            type = value;
        }
    }
    //public string? Type { get; set; }

    public int IdOfProducer { get; set; }

    public Producer? Producer { get; set; }

    [Range(5, 9, ErrorMessage = "value must be in range 5 - 9")]
	public float PH { get; set; }

    [Required]
    public List<CationsList> CationsLists { get; set; } = new();

    [Required]
    public List<AnionsList> AnionsLists { get; set; } = new();

    public string? Mineralization { get; set; }

    public string? PackingType { get; set; }

    public float Volume { get; set; }

    public string? ImageData { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public int AvailableAmount { get; set; }

    public static implicit operator Product(List<Product> v)
    {
        throw new NotImplementedException();
    }
}