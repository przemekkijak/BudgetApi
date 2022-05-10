using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Domain;
using BudgetApp.Domain.Entities;
using BudgetApp.Domain.Interfaces;
using BudgetApp.Domain.Models;

namespace BudgetApp.Core.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<ExecutionResult<BudgetModel>> CreateBudget(int userId, string name, bool isDefault = false)
        {
            var existing = await _budgetRepository.GetForUserByName(userId, name);
            if (existing != null)
            {
                return new ExecutionResult<BudgetModel>(new ErrorInfo(ErrorCodes.BudgetError, "Budget already exists"));
            }
        
            var createdBudget = await _budgetRepository.CreateAsync(new BudgetEntity()
            {
                Name = name,
                UserId = userId,
                CreateDate = TimeService.Now,
                UpdateDate = TimeService.Now
            });
        
            return new ExecutionResult<BudgetModel>(ModelFactory.Create(createdBudget));
        }

        public async Task<ExecutionResult<List<BudgetModel>>> GetAllForUser(int userId)
        {
            var budgets = (await _budgetRepository.GetAllForUser(userId)).Select(ModelFactory.Create);
            return new ExecutionResult<List<BudgetModel>>(budgets.ToList());
        }

        public async Task<ExecutionResult<BudgetModel>> GetDefaultForUser(int userId)
        {
            var budget = await _budgetRepository.GetDefaultForUser(userId);
            if (budget == null)
            {
                return new ExecutionResult<BudgetModel>(new ErrorInfo(ErrorCodes.BudgetError, "Budget not found"));
            }

            return new ExecutionResult<BudgetModel>(ModelFactory.Create(budget));
        }

        public async Task<ExecutionResult<BudgetModel>> SetDefault(int budgetId)
        {
            var existing = await _budgetRepository.GetById(budgetId);
            if (existing == null)
            {
                return new ExecutionResult<BudgetModel>(new ErrorInfo(ErrorCodes.BudgetNotFound, "Budget not found"));
            }

            var currentDefault = await _budgetRepository.GetDefaultForUser(existing.UserId);
            if (currentDefault != null)
            {
                if (existing.Id == currentDefault.Id)
                {
                    return new ExecutionResult<BudgetModel>(ModelFactory.Create(existing));
                }

                currentDefault.IsDefault = false;
            }

            existing.IsDefault = true;
            await _budgetRepository.SaveChangesAsync();

            return new ExecutionResult<BudgetModel>(ModelFactory.Create(existing));
        }
    }
}