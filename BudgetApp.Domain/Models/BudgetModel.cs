using System;

namespace BudgetApp.Domain.Models
{
    public class BudgetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDefault { get; set; }
    }
}