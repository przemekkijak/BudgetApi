using System;

namespace BudgetApp.Domain.Models
{
    public class BudgetModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}