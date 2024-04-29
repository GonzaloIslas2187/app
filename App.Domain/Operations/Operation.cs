using System.ComponentModel.DataAnnotations;

namespace App.Domain.Operations;

public class Operation
{
    [Key]
    public long CardNumber { get; set; }
    public DateTime Date { get; set; }
    public int Amount { get; set; }
}
