using Loyalty_System.Data;
using Loyalty_System.Interfaces;
using Loyalty_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_System.Repositories
{
    public class RecordsRepository : IRecordsRepository
    {
        private readonly ApplicationDbContext _context;
        public RecordsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AccumulatePointsLog>> GetAccumulatePointsLogsAsync(int customerId)
        {
            List<AccumulatePointsLog> accumulatePointsLogs = await _context.AccumulatePointsLogs.Where(l => l.CustomerId == customerId).ToListAsync(); 
            return accumulatePointsLogs;
        }

        public async Task<List<SpendPointsLog>> GetSpendPointsLogsAsync(int customerId)
        {
            List<SpendPointsLog> spendPointsLogs = await _context.SpendPointsLogs.Where(l => l.CustomerId == customerId).ToListAsync();
            return spendPointsLogs;
        }
    }
}
