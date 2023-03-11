using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WemaAnalyticsAPI.Contracts.V1;
using WemaAnalyticsAPI.Contracts.V1.Request;
using WemaAnalyticsAPI.Services;

namespace WemaAnalyticsAPI.Controllers.V1
{
  public class MPRReportController : ControllerBase
  {
    private readonly IMPRReport _mprReportService;

    public MPRReportController(IMPRReport mprReportService)
    {
      _mprReportService = mprReportService;
    }

    [HttpGet(ApiRoutes.Reports.MPR_Report.GetAll)]
    public async Task<IActionResult> GetMPRBalanceSheet(GetMPRReport request)
    {
      try
      {
        var data = await _mprReportService.GetMPRBalanceSheetReport(request);
        return new OkObjectResult(data);
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult("Something unexpected happened " + e.Message);
      }
    }

    [HttpGet(ApiRoutes.Reports.MPR_Report.GetAllTest)]
    public async Task<IActionResult> GetMPRBalanceSheetTest(GetMPRReport request)
    {
      try
      {
        var data = await _mprReportService.GetMPRBalanceSheetReportTest(request);
        return new OkObjectResult(data);
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult("Something unexpected happened " + e.Message);
      }
    }

    [HttpGet(ApiRoutes.Reports.MPR_Report.GetAllIncomeStatement)]
    public async Task<IActionResult> GetIncomeStatement(GetMPRIncomeReport request)
    {
      try
      {
        var data = await _mprReportService.GetMPRIncomeStatementReport(request);
        return new OkObjectResult(data);
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult("Something unexpected happened " + e.Message);
      }
    }

    [HttpGet(ApiRoutes.Reports.MPR_Report.GetAllIncomeStatementAccount)]
    public async Task<IActionResult> GetMPRIncomeStatementAccount(GetMPRIncomeStatementAccount request)
    {
      try
      {
        var data = await _mprReportService.GetMPRIncomeStatementAccount(request);
        return new OkObjectResult(data);
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult("Something unexpected happened " + e.Message);
      }
    }

    [HttpGet(ApiRoutes.Reports.MPR_Report.GetLandingViewData)]
    public async Task<IActionResult> GetLandingViewData(GetMPRLandingViewReport request)
    {
      try
      {
        var data = await _mprReportService.GetMPRLandingViewData(request);
        return new OkObjectResult(data);
      }
      catch (Exception e)
      {
        return new BadRequestObjectResult("Something unexpected happened " + e.Message);
      }
    }

  }
}
