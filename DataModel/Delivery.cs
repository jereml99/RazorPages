using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Delivery
{
    [Key]
    public int Id { get; set; }

	[Required]
	public string? Name { get; set; }

	[Required]
	[EmailAddress]
    public string? Email { get; set; }

	[Required(ErrorMessage = "You must provide a phone number")]
	[Display(Name = "Phone in format (000-000-000)")]
	[DataType(DataType.PhoneNumber)]
	[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid phone number")]
	public string? Phone { get; set; }

    public string? Worker { get; set; }

	[Required]
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
    public int Pallets { get; set; }

	[Required]
	public List<Order>? Order { get; set; }

	[Required]
	public string? Data { get; set; }

    public static implicit operator Delivery(List<Product> v)
    {
        throw new NotImplementedException();
    }
}