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
    }
}