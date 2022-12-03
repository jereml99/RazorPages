using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Cation : IIon
{
    [Key]
    public int Id { get; init; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Symbol { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:E2}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"[0-9]([,\.][0-9]{1,3}([eE][-\+][0-9]{1,3})?)?")]
    public double Concentration { get; set; }
}