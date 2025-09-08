using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class BatchService
    {
        private readonly CascadeDbContext? _context;

        public BatchService(CascadeDbContext? context = null)
        {
            _context = context;
        }

        public async Task<List<BatchList>> GetBatchesAsync()
        {
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                await Task.Delay(10);
                return new List<BatchList>
                {
                    new BatchList 
                    { 
                        BatchID = 1, 
                        BatchNumber = "BATCH-001", 
                        Status = "In Progress", 
                        PartsCount = 150, 
                        PluggedWeight = 12.5, 
                        EstFinishDate = DateTime.Now.AddDays(3)
                    },
                    new BatchList 
                    { 
                        BatchID = 2, 
                        BatchNumber = "BATCH-002", 
                        Status = "Completed", 
                        PartsCount = 200, 
                        PluggedWeight = 18.7, 
                        EstFinishDate = DateTime.Now.AddDays(-5)
                    },
                    new BatchList 
                    { 
                        BatchID = 3, 
                        BatchNumber = "BATCH-003", 
                        Status = "Queued", 
                        PartsCount = 75, 
                        PluggedWeight = 8.3, 
                        EstFinishDate = DateTime.Now.AddDays(7)
                    },
                    new BatchList 
                    { 
                        BatchID = 4, 
                        BatchNumber = "BATCH-004", 
                        Status = "In Progress", 
                        PartsCount = 300, 
                        PluggedWeight = 25.9, 
                        EstFinishDate = DateTime.Now.AddDays(1)
                    },
                    new BatchList 
                    { 
                        BatchID = 5, 
                        BatchNumber = "BATCH-005", 
                        Status = "On Hold", 
                        PartsCount = 120, 
                        PluggedWeight = 14.2, 
                        EstFinishDate = DateTime.Now.AddDays(10)
                    }
                };
            }

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
            // Mock data for UI testing when database is not available
            if (_context == null)
            {
                var batches = await GetBatchesAsync();
                return batches.FirstOrDefault(b => b.BatchID == batchId);
            }

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
            if (_context == null)
            {
                await Task.Delay(10);
                return batch;
            }

            _context.BatchList.Add(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task<BatchList> UpdateBatchAsync(BatchList batch)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return batch;
            }

            _context.BatchList.Update(batch);
            await _context.SaveChangesAsync();
            return batch;
        }

        public async Task DeleteBatchAsync(int batchId)
        {
            if (_context == null)
            {
                await Task.Delay(10);
                return;
            }

            var batch = await _context.BatchList.FindAsync(batchId);
            if (batch != null)
            {
                _context.BatchList.Remove(batch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
