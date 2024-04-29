namespace App.DTOs
{
    public class BalanceDto
    {
        public string UserName { get; set; }

        public int AccountNumber { get; set; }

        public int CurrentBalance { get; set; }

        public DateTime LastExtraction { get; set; }

    }
}
