using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class Producer
{
    [Key]
    public int Id { get; init; }
        
    public string? Name { get; set; }

    [EmailAddress]
    public string? Email { get; set; }
        
    [Phone]
    public string? Phone { get; set; }
}