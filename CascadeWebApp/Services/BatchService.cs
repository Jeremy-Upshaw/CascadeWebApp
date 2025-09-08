using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class BatchService
    {
        private readonly CascadeDbContext _context;

        public BatchService(CascadeDbContext context)
        {
            _context = context;
        }

        public async Task<List<BatchList>> GetBatchesAsync()
        {
            return await _context.BatchList
                .Include(b => b.BatchContents)
                .ThenInclude(bc => bc.Item)
                .Include(b => b.BatchLoss)
                .Include(b => b.BatchAssignments)
                .ThenInclude(ba => ba.Order)
                .ToListAsync();
        }

        public async Task<BatchList?> GetBatchByIdAsync(int batchId)
        {
            return await _context.BatchList
                .Include(b => b.BatchContents)
                .ThenInclude(bc => bc.Item)
                .Include(b => b.BatchLoss)
                .Include(b => b.BatchAssignments)
                .ThenInclude(ba => ba.Order)
                .FirstOrDefaultAsync(b => b.BatchID == batchId);
        }

        public async Task<BatchList> CreateBatchAsync(BatchList batch)
        {
            _context.BatchList.Add(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task<BatchList> UpdateBatchAsync(BatchList batch)
        {
            _context.BatchList.Update(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task DeleteBatchAsync(int batchId)
        {
            var batch = await _context.BatchList.FindAsync(batchId);
            if (batch != null)
            {
                _context.BatchList.Remove(batch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
