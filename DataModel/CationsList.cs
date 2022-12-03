using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class CationsList
{
    [Key]
    public int Id { get; set; }
    public Product? IdOfProduct { get; set; }
    public int IdOfCation { get; set; }
}