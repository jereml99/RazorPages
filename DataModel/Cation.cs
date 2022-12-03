using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Cation : IIon
{
    [Key]
    public int Id { get; init; }
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    [DisplayFormat(DataFormatString = "{0:E2}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"[0-9]([,\.][0-9]{1,3}(-[Ee][0-9]{2})?)?")]
    public double Concentration { get; set; }
}