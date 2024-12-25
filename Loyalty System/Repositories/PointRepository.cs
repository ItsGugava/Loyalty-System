using Loyalty_System.Data;
using Loyalty_System.Interfaces;
using Loyalty_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_System.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly ApplicationDbContext _context;
        
        public PointRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AccumulatePointsAsync(AccumulatePointsLog accumulatePointsLog)
        {
            Customer? customer = _context.Customers.FirstOrDefault(c => c.Id == accumulatePointsLog.CustomerId);
            if(customer == null)
            {
                return false;
            }
            await _context.AccumulatePointsLogs.AddAsync(accumulatePointsLog);
            customer.Points += accumulatePointsLog.Points;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AccumulatePointsLog?> ReverseAccumulatePointsAsync(int checkId)
        {
            AccumulatePointsLog? accumulatePointsLog = await _context.AccumulatePointsLogs.FirstOrDefaultAsync(l => l.CheckId == checkId);
            if(accumulatePointsLog == null)
            {
                return null;
            }
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == accumulatePointsLog.CustomerId);
            _context.AccumulatePointsLogs.Remove(accumulatePointsLog);
            customer.Points -= accumulatePointsLog.Points;
            await _context.SaveChangesAsync();
            return accumulatePointsLog;
        }

        public async Task<SpendPointsLog?> ReverseSpendPointsAsync(int checkId)
        {
            SpendPointsLog? spendPointsLog = await _context.SpendPointsLogs.FirstOrDefaultAsync(l => l.CheckId == checkId);
            if(spendPointsLog == null)
            {
                return null;
            }
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == spendPointsLog.CustomerId);
            _context.SpendPointsLogs.Remove(spendPointsLog);
            customer.Points += spendPointsLog.Points;
            await _context.SaveChangesAsync();
            return spendPointsLog;
        }

        public async Task<bool> SpendPointsAsync(SpendPointsLog spendPointsLog)
        {
            Customer? customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == spendPointsLog.CustomerId);
            if(customer == null)
            {
                return false;
            }
            if(customer.Points < spendPointsLog.Points)
            {
                return false;
            }
            await _context.SpendPointsLogs.AddAsync(spendPointsLog);
            customer.Points -= spendPointsLog.Points;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
