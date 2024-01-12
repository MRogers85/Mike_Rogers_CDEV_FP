using Microsoft.AspNetCore.Mvc;
using Mike_Rogers_CDEV_FP.Filters;
using Mike_Rogers_CDEV_FP.Filters.ActionFilter;
using Mike_Rogers_CDEV_FP.Filters.ExceptionFilters;
using Mike_Rogers_CDEV_FP.Models;
using Mike_Rogers_CDEV_FP.Models.Repositories;
using System.Linq;

namespace Mike_Rogers_CDEV_FP.Controllers 
{
    [ApiController]
    [Route("api/controller")]
    public class CandleController : ControllerBase
    {

        [HttpGet]
        public IActionResult CandleDatabase()
        {
            return Ok(CandlesRepository.GetCandles()); 
        }

        [HttpGet("{id}")]
        [Candles_ValidateCandleIdFilter]
        public IActionResult GetCandlesById(int id)
        {
            return Ok(CandlesRepository.GetCandlesById(id));
        }

        [HttpPost]
        [Candles_ValidateCreateCandleFilter]
        public IActionResult CreateCandles([FromForm] Candles candles)
        {
            CandlesRepository.AddCandle(candles);
            return CreatedAtAction(nameof(GetCandlesById),
                new { id = candles.Id },
                candles);
        }

        [HttpPut("{id}")]
        [Candles_ValidateCandleIdFilter]
        [Candles_ValidateUpdateCandleFilter]
        [Candles_HandleUpdateExceptionsFilter]
        public IActionResult UpdateCandles(int id, Candles candles)
        {
            CandlesRepository.UpdateCandles(candles);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Candles_ValidateCandleIdFilter]
        public IActionResult DeleteCandles(int id)
        {
            var candle = CandlesRepository.GetCandlesById(id);
            CandlesRepository.DeleteCandle(id);
            return Ok(candle);
        }

    }
}

