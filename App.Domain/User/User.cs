using App.Domain.Operations;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.User;

public class User
{
    [Key]
    public long CardNumber { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int AccountNumber { get; set; }
    public int CurrentBalance
    {
        get
        {
            if (Operations == null)
                return CurrentBalance;
            var balance = 0;
            foreach (var op in Operations)
                balance = balance + op.Amount;
            return balance;
        }
        set { }
    }
    public DateTime LastExtraction
    {
        get { return Operations.OrderByDescending(x => x.Date).FirstOrDefault().Date; }
        set { }
    }
    public int FailedTries { get; set; } = 0;
    public bool IsLockedOut { get; set; }
    public virtual List<Operation> Operations { get; set; }
}

