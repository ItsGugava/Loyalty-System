using Loyalty_System.Models;

namespace Loyalty_System.Interfaces
{
    public interface IRecordsRepository
    {
        Task<List<AccumulatePointsLog>> GetAccumulatePointsLogsAsync(int customerId);
        Task<List<SpendPointsLog>> GetSpendPointsLogsAsync(int customerId);
    }
}
