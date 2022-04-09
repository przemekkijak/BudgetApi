using System;

namespace BudgetApp.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}