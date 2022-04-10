using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Domain.Entities
{
    public class TransactionEntity : EntityBase
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("budget_id")]
        public int BudgetId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public virtual BudgetEntity Budget { get; set; }
    }
}