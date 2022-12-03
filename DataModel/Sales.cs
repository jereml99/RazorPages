using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Sales
{
    [Key]
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public List<SalesList>? SalesList { get; set; }

    public string? Date { get; set; }
}