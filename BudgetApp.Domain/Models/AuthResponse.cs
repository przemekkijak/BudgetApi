namespace BudgetApp.Domain.Models
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}