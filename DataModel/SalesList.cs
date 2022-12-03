using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class SalesList
{
    [Key]
    public int Id { get; set; }
    public Sales? IdOfSale { get; set; }
    [Required]
    public int Amount { get; set; }
    public int IdOfProduct { get; set; }
    public string? ProductName { get; set; }
}