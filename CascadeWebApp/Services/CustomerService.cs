using Microsoft.EntityFrameworkCore;
using CascadeWebApp.Models;
using CascadeWebApp.Data;

namespace CascadeWebApp.Services
{
    public class CustomerService
    {
        private readonly CascadeDbContext _context;

        public CustomerService(CascadeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customers>> GetCustomersAsync()
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderContents)
                .ToListAsync();
        }

        public async Task<Customers?> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderContents)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId);
        }

        public async Task<Customers> CreateCustomerAsync(Customers customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customers> UpdateCustomerAsync(Customers customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
