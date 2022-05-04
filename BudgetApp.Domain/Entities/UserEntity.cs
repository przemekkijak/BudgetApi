using System.Text.Json.Serialization;

namespace BudgetApp.Domain.Entities
{
    public class UserEntity : EntityBase
    {
        public virtual string Name { get; set; }

        public string Phone { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}