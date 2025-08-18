using CascadeWebApp.Models;

namespace CascadeWebApp.Services
{
    public class BatchService
    {
        public Task<List<Batch>> GetBatchesAsync()
        {
            // Placeholder data
            var batches = new List<Batch>
            {
                new Batch{ BatchID=1, BatchNumber="BATCH1001", Status="Open", PartsCount=100, PluggedWeight=55.5, EstFinishDate=DateTime.Now.AddDays(2) },
                new Batch{ BatchID=2, BatchNumber="BATCH1002", Status="Closed", PartsCount=80, PluggedWeight=44.2, EstFinishDate=DateTime.Now.AddDays(-1) }
            };
            return Task.FromResult(batches);
        }
    }
}
