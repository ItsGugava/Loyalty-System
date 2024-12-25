using Loyalty_System.Models;

namespace Loyalty_System.Interfaces
{
    public interface IPointRepository
    {
        Task<bool> AccumulatePointsAsync(AccumulatePointsLog accumulatePointsLog);
        Task<AccumulatePointsLog?> ReverseAccumulatePointsAsync(int checkId);
        Task<SpendPointsLog?> ReverseSpendPointsAsync(int checkId);
        Task<bool> SpendPointsAsync(SpendPointsLog spendPointsLog);
    }
}
