using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Mike_Rogers_CDEV_FP.Models.Repositories;

namespace Mike_Rogers_CDEV_FP.Filters.ActionFilter
{
    public class Candles_ValidateCandleIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var candleId = context.ActionArguments["id"] as int?;
            if (candleId.HasValue)
            {
                if (candleId.Value <= 0)
                {
                    context.ModelState.AddModelError("CandleId", "CandleId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!CandlesRepository.CandlesExists(candleId.Value))
                {
                    context.ModelState.AddModelError("CandleId", "CandleId does not exist");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetail);
                }
            }
        }
    }
}
