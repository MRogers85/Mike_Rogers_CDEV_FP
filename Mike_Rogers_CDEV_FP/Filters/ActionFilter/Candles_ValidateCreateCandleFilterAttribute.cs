using Mike_Rogers_CDEV_FP.Models.Repositories;
using Mike_Rogers_CDEV_FP.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Mike_Rogers_CDEV_FP.Filters.ActionFilter
{
    public class Candles_ValidateCreateCandleFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var candle = context.ActionArguments["candles"] as Candles;

            if (candle == null)
            {
                context.ModelState.AddModelError("Candles", "Candles object is null");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingCandle = CandlesRepository.GetCandlesByProperties(candle.Type, candle.Size, candle.Scent, candle.Color, candle.Price);
                if (existingCandle != null)
                {
                    context.ModelState.AddModelError("Candles", "Candles object is null");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }

        }

    }
}
