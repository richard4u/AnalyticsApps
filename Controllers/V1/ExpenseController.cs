using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet(ApiRoutes.Reports.BranchesExpense.GetAllBranchesExpense)]
        public async Task<IActionResult> GetBranchesExpenseReport(GetExpenseRequest expenseRequest)
        {
            try
            {
                var data = await _expenseService.GetBranchesExpenseReports(expenseRequest);
                return new OkObjectResult(data);
            } catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }

        [HttpGet(ApiRoutes.Reports.BranchesExpense.GetBranchesExpenseTransactions)]
        public async Task<IActionResult> GetBranchesExpenseTransactions(GetExpenseTransactions expenseTransactions)
        {
            try
            {
                var data = await _expenseService.GetBranchesExpenseTransactionsReports(expenseTransactions);
                return new OkObjectResult(data);
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
           
        }

        [HttpGet(ApiRoutes.Reports.HeadOfficeExpense.GetAllHeadOfficeExpense)]
        public async Task<IActionResult> GetAllHeadOfficeExpense(GetHeadOfficeExpenseRequest request)
        {
            try
            {
                var data = await _expenseService.GetHeadOfficeExpenseReports(request);
                return new OkObjectResult(data);
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
           
        }

        [HttpGet(ApiRoutes.Reports.HeadOfficeExpense.GetHeadOfficeExpenseTransactions)]
        public async Task<IActionResult> GetHeadOfficeExpenseTransactions(GetHeadOfficeTransactions request)
        {
            try
            {
                var data = await _expenseService.GetHeadOfficeExpenseTransactionsReports(request);
                return new OkObjectResult(data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }

        [HttpGet(ApiRoutes.Reports.RetailExpense.GetAllRetailExpense)]
        public async Task<IActionResult> GetRetailExpenseReport(GetRetailExpenseRequest request)
        {
            try
            {
                var data = await _expenseService.GetRetailExpenseReports(request);
                return new OkObjectResult(data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }

        [HttpGet(ApiRoutes.Reports.RetailExpense.GetRetailExpenseTransactions)]
        public async Task<IActionResult> GetRetailExpenseTransactions(GetRetailExpenseTransactions request)
        {
            try
            {
                var data = await _expenseService.GetRetailExpenseTransactions(request);
                return new OkObjectResult(data);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something unexpected happened " + e.Message);
            }
        }
    }
}
