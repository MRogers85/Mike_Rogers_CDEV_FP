using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mike_Rogers_CDEV_FP.Models;

namespace Mike_Rogers_CDEV_FP.Filters.ActionFilter
{
    public class Candles_ValidateUpdateCandleFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var candle = context.ActionArguments["candles"] as Candles;

            if (id.HasValue && candle != null && id != candle.Id)
            {
                context.ModelState.AddModelError("CandleId", "CandleId is not the same as my id");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
