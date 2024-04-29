namespace App.DTOs;
public class WithdrawalResponseDto
{
    public string Message { get; set; }

    public int PreviousBalance { get; set; }

    public int AmountWithdrawn { get; set; }

    public int NewBalance { get; set; }
}
