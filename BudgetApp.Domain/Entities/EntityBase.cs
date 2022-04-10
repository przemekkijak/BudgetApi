using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}