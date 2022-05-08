using System;
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

        public async Task<ExecutionResult<BudgetModel>> CreateBudget(int userId, string name)
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
    }
}