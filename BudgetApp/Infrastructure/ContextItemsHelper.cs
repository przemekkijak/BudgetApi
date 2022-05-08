using BudgetApp.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace BudgetApp.Infrastructure
{
    public static class ContextItemsHelper
    {
        public static object? GetContextItem(this HttpContext context, string itemName)
        {
            return context.Items[itemName];
        }

        public static int GetUserId(this HttpContext context)
        {
            var userItem = GetContextItem(context, ContexItemsNamesHelper.User);
            if (userItem == null) return 0;
            
            var userModel = (UserModel)userItem;
            return userModel.Id;
        }
    }
}