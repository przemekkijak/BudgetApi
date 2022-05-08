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
    }
}