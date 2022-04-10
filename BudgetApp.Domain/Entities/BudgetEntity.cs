using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Domain.Entities
{
    public class BudgetEntity : EntityBase
    {
        [Column("user_id")]
        public int UserId { get; set; }

        public virtual IList<TransactionEntity> Transactions { get; set; }
    }
}