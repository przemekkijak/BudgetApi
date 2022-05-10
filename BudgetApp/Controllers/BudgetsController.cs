using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetApp.AuthMiddleware;
using BudgetApp.Domain;
using BudgetApp.Domain.Interfaces;
using BudgetApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    [ApiController]
    [Route("api/budgets")]
    public class BudgetsController : ApiControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetsController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        
        [HttpPost]
        [Authorize]
        public async Task<ExecutionResult<BudgetModel>> CreateBudget([FromBody] string name)
        {
            return await _budgetService.CreateBudget(UserId, name);
        }

        [HttpGet]
        [Authorize]
        public async Task<ExecutionResult<BudgetModel>> GetDefault()
        {
            return await _budgetService.GetDefaultForUser(UserId);
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<ExecutionResult<List<BudgetModel>>> GetAll()
        {
            return await _budgetService.GetAllForUser(UserId);
        }

        [HttpPost("default/{budgetId}")]
        [Authorize]
        public async Task<ExecutionResult<BudgetModel>> SetDefault(int budgetId)
        {
            return await _budgetService.SetDefault(budgetId);
        }
    }
}