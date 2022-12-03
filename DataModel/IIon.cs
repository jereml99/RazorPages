using JetBrains.Annotations;

namespace DataModel;

internal interface IIon
{
    [UsedImplicitly] public int Id { get; init; }
    [UsedImplicitly] public string? Name { get; set; }
    [UsedImplicitly] public string? Symbol { get; set; }
    [UsedImplicitly] public double Concentration { get; set; }
}