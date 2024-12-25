using Loyalty_System.Dtos.AccumulatePoints;
using Loyalty_System.Dtos.SpendPoints;
using Loyalty_System.Interfaces;
using Loyalty_System.Mappers;
using Loyalty_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_System.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IPointRepository _pointRepo;

        public PointsController(IPointRepository pointRepo)
        {
            _pointRepo = pointRepo;
        }

        [HttpPost("AccomulatePoints")]
        public async Task<IActionResult> AccumulatePoints([FromBody] AccumulatePointsRequestDto accumulatePointsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccumulatePointsLog accumulatePointsLog = accumulatePointsDto.ToAccumulatePointsLog();
            bool isSuccess = await _pointRepo.AccumulatePointsAsync(accumulatePointsLog);
            if(!isSuccess)
            {
                return NotFound();
            }
            return Ok(accumulatePointsLog.ToAccumulatePointsLogDto());
        }
        [HttpDelete]
        [Route("ReverseAccomulatePoints/{checkId}")]
        public async Task<IActionResult> ReverseAccumulatePoints([FromRoute] int checkId)
        {
            AccumulatePointsLog? accumulatePointsLog = await _pointRepo.ReverseAccumulatePointsAsync(checkId);
            if(accumulatePointsLog == null)
            {
                return NotFound();
            }
            return Ok("Accumulate Points is reversed");
        }

        [HttpPost("SpendPoints")]
        public async Task<IActionResult> SpendPoints([FromBody] SpendPointsRequestDto spendPointsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SpendPointsLog spendPointsLog = spendPointsDto.ToSpendPointsLog();
            bool isSuccess = await _pointRepo.SpendPointsAsync(spendPointsLog);
            if(!isSuccess)
            {
                return BadRequest("Not enough points");
            }
            return Ok(spendPointsLog.ToSpendPointsLogDto());
        }

        [HttpDelete]
        [Route("ReverseSpendPoints/{checkId}")]
        public async Task<IActionResult> ReverseSpendPoints([FromRoute] int checkId)
        {
            SpendPointsLog? spendPointsLog = await _pointRepo.ReverseSpendPointsAsync(checkId);
            if(spendPointsLog == null)
            {
                return NotFound();
            }
            return Ok("Spend Points is reversed");
        }
    }
}
