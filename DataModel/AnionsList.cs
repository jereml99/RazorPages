using System.ComponentModel.DataAnnotations;

namespace DataModel;

public class AnionsList
{
    [Key]
    public int Id { get; set; }
    public Product? IdOfProduct { get; set; }
    public int IdOfAnion { get; set; }
}