using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Producer
{
    [Key]
    public int Id { get; init; }

	[Required]
	[RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
	public string? Name { get; set; }

	[Required]
	[EmailAddress]
    public string? Email { get; set; }

	[Required(ErrorMessage = "You must provide a phone number")]
	[Display(Name = "Phone in format (000-000-000)")]
	[DataType(DataType.PhoneNumber)]
	[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid phone number")]
	public string? Phone { get; set; }
}