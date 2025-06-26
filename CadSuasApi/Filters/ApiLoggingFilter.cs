using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadSuasApi.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
    {
      _logger = logger;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      _logger.LogInformation("### executando");
      _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      _logger.LogInformation("### executando pós OnActionExecuted");
      _logger.LogInformation($"ModelState: {context.HttpContext.Response.StatusCode}");
    }
  }
}