using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Delivery
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "wrong format")]
    public string? Phone { get; set; }

    public string? Worker { get; set; }

    public int Pallets { get; set; }

    public List<Order>? Order { get; set; }

    public string? Data { get; set; }

    public static implicit operator Delivery(List<Product> v)
    {
        throw new NotImplementedException();
    }
}