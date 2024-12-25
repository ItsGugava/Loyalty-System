using Loyalty_System.Dtos.AccumulatePoints;
using Loyalty_System.Models;

namespace Loyalty_System.Mappers
{
    public static class AccumulatePointsMapper
    {
        public static AccumulatePointsLog ToAccumulatePointsLog(this AccumulatePointsRequestDto accumulatePointsDto)
        {
            return new AccumulatePointsLog
            {
                CheckId = accumulatePointsDto.CheckId,
                CustomerId = accumulatePointsDto.CustomerId,
                Amount = accumulatePointsDto.Amount,
                Points = (int)accumulatePointsDto.Amount
            };
        }

        public static AccumulatePointsLogDto ToAccumulatePointsLogDto(this AccumulatePointsLog accumulatePointsLog)
        {
            return new AccumulatePointsLogDto
            {
                Id = accumulatePointsLog.Id,
                CheckId = accumulatePointsLog.CheckId,
                CustomerId = accumulatePointsLog.CustomerId,
                Amount = accumulatePointsLog.Amount,
                Points = accumulatePointsLog.Points,
                DateTime = accumulatePointsLog.DateTime
            };
        }
    }
}
