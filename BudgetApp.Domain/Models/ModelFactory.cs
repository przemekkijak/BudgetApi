using BudgetApp.Domain.Entities;

namespace BudgetApp.Domain.Models
{
    public class ModelFactory
    {
        public static UserModel Create(UserEntity entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                Email = entity.Email,
                Phone = entity.Phone
            };
        }

        public static BudgetModel Create(BudgetEntity entity)
        {
            return new BudgetModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                UserId = entity.UserId,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
                IsDefault = entity.IsDefault
            };
        }

        public static TransactionModel Create(TransactionEntity entity)
        {
            return new TransactionModel()
            {
                UserId = entity.UserId,
                BudgetId = entity.BudgetId,
                Amount = entity.Amount,
                Description = entity.Description,
                IsPaid = entity.IsPaid,
                PaymentDate = entity.PaymentDate
            };
        }
    }
}