using Loyalty_System.Dtos.AccumulatePoints;
using Loyalty_System.Dtos.SpendPoints;
using Loyalty_System.Models;

namespace Loyalty_System.Mappers
{
    public static class SpendPointsMapper
    {
        public static SpendPointsLog ToSpendPointsLog(this SpendPointsRequestDto spendPointsRequestDto)
        {
            return new SpendPointsLog
            {
                CheckId = spendPointsRequestDto.CheckId,
                CustomerId = spendPointsRequestDto.CustomerId,
                Amount = spendPointsRequestDto.Amount,
                Points = (int) (spendPointsRequestDto.Amount * 100)
            };
        }

        public static SpendPointsLogDto ToSpendPointsLogDto(this SpendPointsLog spendPointsLog)
        {
            return new SpendPointsLogDto
            {
                Id = spendPointsLog.Id,
                CheckId = spendPointsLog.CheckId,
                CustomerId = spendPointsLog.CustomerId,
                Amount = spendPointsLog.Amount,
                Points = spendPointsLog.Points,
                DateTime = spendPointsLog.DateTime
            };
        }
    }
}
