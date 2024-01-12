using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mike_Rogers_CDEV_FP.Models.Repositories;

namespace Mike_Rogers_CDEV_FP.Filters.ExceptionFilters
{
    public class Candles_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strCandleId = context.RouteData.Values["id"] as string;

            if (int.TryParse(strCandleId, out int CandleId))
            {
                if (!CandlesRepository.CandlesExists(CandleId)) 
                {
                    context.ModelState.AddModelError("Id", "Candle does not exist anymore.");

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
