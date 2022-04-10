namespace BudgetApp.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public virtual string Name { get; set; }

        public string Phone { get; set; }
    }
}