using Loyalty_System.Dtos.AccumulatePoints;
using Loyalty_System.Dtos.SpendPoints;
using Loyalty_System.Interfaces;
using Loyalty_System.Mappers;
using Loyalty_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_System.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsRepository _recordsRepo;

        public RecordsController(IRecordsRepository recordsRepo)
        {
            _recordsRepo = recordsRepo;
        }

        [HttpGet]
        [Route("AccumulatePointsLogs/{customerId}")]
        public async Task<IActionResult> GetAccumulatePointsLogs([FromRoute] int customerId)
        {
            List<AccumulatePointsLog> accumulatePointsLogs = await _recordsRepo.GetAccumulatePointsLogsAsync(customerId);
            List<AccumulatePointsLogDto> accumulatePointsLogDtos = accumulatePointsLogs.Select(l => l.ToAccumulatePointsLogDto()).ToList();
            return Ok(accumulatePointsLogDtos);
        }

        [HttpGet]
        [Route("SpendPointsLogs/{customerId}")]
        public async Task<IActionResult> GetSpendPointsLogs([FromRoute] int customerId)
        {
            List<SpendPointsLog> spendPointsLogs = await _recordsRepo.GetSpendPointsLogsAsync(customerId);
            List<SpendPointsLogDto> spendPointsLogDtos = spendPointsLogs.Select(l => l.ToSpendPointsLogDto()).ToList();
            return Ok(spendPointsLogDtos);
        }
    }
}
