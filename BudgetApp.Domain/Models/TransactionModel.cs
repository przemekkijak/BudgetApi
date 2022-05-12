using System;

namespace BudgetApp.Domain.Models
{
    public class TransactionModel
    {
        public int UserId { get; set; }

        public int BudgetId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public bool IsPaid { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}