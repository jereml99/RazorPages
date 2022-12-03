using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Anion : IIon
{
    [Key]
    public int Id { get; init; }
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public double Concentration { get; set; }
}