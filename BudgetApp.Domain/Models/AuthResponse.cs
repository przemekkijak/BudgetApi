namespace BudgetApp.Domain.Models
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}