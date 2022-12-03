using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Order
{
    [Key]
    public int Id { get; set; }
    public Delivery? IdOfDelivery { get; set; }
    public int Amount { get; set; }
    public int IdOfProduct { get; set; }
    public string? ProductName { get; set; }
}