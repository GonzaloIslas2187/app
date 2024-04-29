namespace App.DTOs
{
    public class LogInDto
    {
        public long CardNumber { get; set; }
        public string Password { get; set; }
        public bool IsPasswordValid { get; set; } = false;
        public bool IsLockedOut { get; set; } = false;
        public string Message { get; set; }
        public string Name { get; set; }
        public string Token { get; set; } = string.Empty;

    }
}
